using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        public float startLife = 10f;
        private float currentLife;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            ResetLife();
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
            Destroy(gameObject);

        }

        public void OnDamage(float f)
        {
            currentLife -= f;

            if (currentLife <= 0)
            {
                Kill();
            }
        }
    }
}
