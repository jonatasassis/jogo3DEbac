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
            boss.GoToRandomPoint();
            Debug.Log("Boss andando");

        }
    }
}
