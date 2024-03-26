using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptsJogo3D.StateMachine;

public class StateBase : MonoBehaviour
{
    public virtual void OnStateEnter(object o= null)
    {
        Debug.Log("Idle");
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

public class Walking : StateBase
{
    public Player player;
    public override void OnStateEnter(object o = null)
    {
        player = (Player)o;
        player.canMove = true;
        player.MudarCor(Color.yellow);
        print("walking");
        base.OnStateEnter(o);
    }

    public override void OnStateExit(object o = null)
    {
        player.MudarCor(Color.white);
        player.canMove = false;
        base.OnStateExit();
    }
   
}

public class Jumping : StateBase
{
    public Player player;
    public override void OnStateEnter(object o = null)
    {
        player = (Player)o;
        player.canMove = true;
        print("jumping");
        player.MudarCor(Color.cyan);
        base.OnStateEnter(o);
    }

    public override void OnStateExit(object o = null)
    {
        player.MudarCor(Color.white);
        player.canMove = false;
        base.OnStateExit();
    }

}
