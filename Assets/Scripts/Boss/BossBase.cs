using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.StateMachine;
using Unity.VisualScripting;
using DG.Tweening;

namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }
    public class BossBase : MonoBehaviour
    {
        [Header("Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase=Ease.OutBack;

        [Header("Attack")]
        public int attackAmount = 1;
        public float timeBetweenAttacks = .5f;
        public GameObject bossMinions;

        public float speed;
        public List<Transform> waypoints;
        private StateMachine <BossAction> stateMachine;
        public HealthBase bossHealthBase;
        public static int amountKillEnemies = 0;
        
       



       
        private void Awake()
        {
            Init();
            bossHealthBase.onKill += OnBossKill;
            amountKillEnemies = 0;
            SwitchWalk();
           
        }
        private void Init()
        {
            stateMachine= new StateMachine <BossAction> ();
            stateMachine.Init ();

            stateMachine.RegisterStates(BossAction.INIT,new BossStateInit());
            stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
            stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
            stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());

        }

        private void OnBossKill(HealthBase h)
        {
            SwitchState(BossAction.DEATH);
        }

        #region WALK
        public void GoToRandomPoint(Action onArive=null)
        {
            StartCoroutine(GoToPointCoroutine(waypoints[UnityEngine.Random.Range(0,waypoints.Count)],onArive));
        }

        IEnumerator GoToPointCoroutine(Transform t,Action onArive = null)
        {
            while(Vector3.Distance(transform.position,t.position)>1f)
            {
                transform.position = Vector3.MoveTowards(transform.position,t.position,Time.deltaTime * speed);
                
                yield return new WaitForEndOfFrame();
            }
            onArive?.Invoke();
        }

        #endregion

        #region ATTACK
        public void StartAttack(Action endCallback=null)
        {
            StartCoroutine(AttackCoroutine(endCallback));
        }

        IEnumerator AttackCoroutine(Action endCallback)
        {
            int attacks = 0;
            while (attacks<attackAmount)
            {
                attacks++;
                
                Instantiate(bossMinions, new Vector3(UnityEngine.Random.Range(551,633),-7.6f, UnityEngine.Random.Range(77, 23)), Quaternion.identity);
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
            endCallback?.Invoke();
        }

        #endregion

        #region ANIMATION
        public void StartInitAnimation()
        {
            transform.DOScale(0,startAnimationDuration).SetEase(startAnimationEase).From();

        }
        #endregion

        #region DEBUG
        [NaughtyAttributes.Button]
        private void SwitchInit() 
        {
            SwitchState(BossAction.INIT);

        }
        [NaughtyAttributes.Button]
        private void SwitchWalk()
        {
            SwitchState(BossAction.WALK);

        }

        [NaughtyAttributes.Button]
        private void SwitchAttack()
        {
            SwitchState(BossAction.ATTACK);

        }
        #endregion

      
        #region STATE MACHINE
        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState (state,this);

        }
        #endregion
    }
}
