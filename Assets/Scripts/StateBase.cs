using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.StateMachine
{

    public class StateBase
    {
        public virtual void onStateEnter(params object[]objs)
        {
            Debug.Log("onStateEnter");
            
        }
        public virtual void onStateStay(object o = null)
        {
            Debug.Log("onStateStay");
            
        }
        public virtual void onStateExit(object o = null)
        {
            Debug.Log("onStateExit");
           
        }
    }


}
