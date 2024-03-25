using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptsJogo3D.StateMachine;
public class FSM : MonoBehaviour
{
    public enum exEnum
    {
        STATE_1,
        STATE_2,
        STATE_3
    }
    public StateMachine<exEnum> stateMachine;
   
    void Start()
    {
        stateMachine= new StateMachine<exEnum> ();
        stateMachine.Init ();
        stateMachine.RegisterStates(exEnum.STATE_1,new StateBase());
        stateMachine.RegisterStates(exEnum.STATE_2, new StateBase());
    }

   
}
