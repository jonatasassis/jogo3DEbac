using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;


namespace Enemy
{
    public class EnemyBase : MonoBehaviour,IDamageable
    {
        public Collider collider;
        public float startLife = 10f;
        private float currentLife;
        public AnimationBase enemyAnimationBase;

        [Header("Start Animation")]
        public float startAnimationDuration = 0.2f;
        public Ease startAnimationEase= Ease.OutBack;


        private void Awake()
        {
            Init();
        }

        private void Init()
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
            PlayAnimationByTrigger(AnimationType.DEATH);

        }

        public void OnDamage(float f)
        {
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
    }
}
