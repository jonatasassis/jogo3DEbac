using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;
using Boss;


namespace Enemy
{
    public class EnemyBase : MonoBehaviour,IDamageable
    {
        public Collider collider;
        public float startLife = 10f;
        private float currentLife;
        public AnimationBase enemyAnimationBase;
        public FlashColor flashColor;
        public ParticleSystem enemyParticleSystem;
        public bool lookAtPlayer=false;
        private Player playerToLookAt;

        [Header("Start Animation")]
        public float startAnimationDuration = 0.2f;
        public Ease startAnimationEase= Ease.OutBack;


        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            playerToLookAt=GameObject.FindObjectOfType<Player>();
        }

        protected virtual void Init()
        {
            ResetLife();
            BornAnimation();
        }

        protected void ResetLife()
        {
            currentLife = startLife;
        }

        protected virtual void Kill()
        {
            OnKill();

        }

        protected virtual void OnKill()
        {
            if (collider != null)
            {
                collider.enabled= false;
            }
            Destroy(gameObject,3f);
            BossBase.amountKillEnemies++;
            print("matei "+BossBase.amountKillEnemies+" inimigos");
            PlayAnimationByTrigger(AnimationType.DEATH);

        }

        public void OnDamage(float f)
        {
            if (flashColor!=null)
            {
                flashColor.Flash();
            }
            if (enemyParticleSystem != null)
            {
                enemyParticleSystem.Emit(15);
            }
            currentLife -= f;

            if (currentLife <= 0)
            {
                Kill();
            }
        }

        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animType)
        {
           enemyAnimationBase.PlayAnimationByTrigger(animType);
           

        }

        public void Damage(float damageAmount)
        {
            OnDamage(damageAmount);
        }
        public void Damage(float damageAmount,Vector3 dir)
        {
            OnDamage(damageAmount);
            transform.DOMoveX(transform.position.x-dir.x,0.1f);
            transform.DOMoveZ(transform.position.z - dir.z, 0.1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p= collision.transform.GetComponent<Player>();

            if(p != null)
            {
                p.Damage(1);
            }
        }
        public virtual void Update()
        {
            if(lookAtPlayer)
            {
                transform.LookAt(playerToLookAt.transform.position);
            }
        }
    }
}
