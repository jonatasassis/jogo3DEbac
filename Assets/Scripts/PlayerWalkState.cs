
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerWalkState : PlayerBaseState
{
    public GameObject player;
    public bool canMove=false;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("entrei no walk state");
        canMove = true;
       
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (canMove == true)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
            canMove= false;
        }
        else if (canMove == false) 
        {
            player.TrocarState(player.idleState);
        }
    }


}
