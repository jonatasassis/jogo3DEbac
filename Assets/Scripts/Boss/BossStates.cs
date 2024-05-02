using Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossStateBase: StateBase
    {
        protected BossBase boss;

        public override void onStateEnter(params object[]objs)
        {
            base.onStateEnter(objs); 
            boss = (BossBase)objs[0];
        }
    }

    public class BossStateInit : BossStateBase
    {
        public override void onStateEnter(params object[] objs)
        {
            base.onStateEnter(objs);
            boss.StartInitAnimation();
            Debug.Log("Boss: "+boss);
        }
    }

    public class BossStateWalk : BossStateBase
    {
        public override void onStateEnter(params object[] objs)
        {
            base.onStateEnter(objs);
            boss.GoToRandomPoint(OnArive);
            Debug.Log("Boss andando");

        }

        private void OnArive()
        {
            boss.SwitchState(BossAction.ATTACK);
        }

        public override void onStateExit(object o = null)
        {
            base.onStateExit(o);
            boss.StopAllCoroutines();
        }
    }

    public class BossStateAttack : BossStateBase
    {
        public override void onStateEnter(params object[] objs)
        {
            base.onStateEnter(objs);
            boss.StartAttack(EndAttacks);
            Debug.Log("Boss atacando");

        }
        private void EndAttacks()
        {
            boss.SwitchState(BossAction.WALK);
        }
        public override void onStateExit(object o = null)
        {
            base.onStateExit(o);
            boss.StopAllCoroutines();
        }
    }

    public class BossStateDeath : BossStateBase
    {
        public override void onStateEnter(params object[] objs)
        {
            base.onStateEnter(objs);
            Debug.Log("Boss morreu");
            boss.transform.localScale= Vector3.one*0.2f;
        }
       
    }
}
