using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptsJogo3D.StateMachine;

public class StateBase : MonoBehaviour
{
    public virtual void OnStateEnter(object o= null)
    {
        Debug.Log("OnStateEnter");
    }

    public virtual void OnStateStay(object o = null)
    {
        Debug.Log("OnStateStay");
    }

    public virtual void OnStateExit(object o = null)
    {
        Debug.Log("OnStateExit");
    }
}
