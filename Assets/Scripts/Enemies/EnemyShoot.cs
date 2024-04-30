using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        public GunBase enemyGunBase;

        protected override void Init()
        {
            base.Init();
            enemyGunBase.StartShoot();
        }
    }
}