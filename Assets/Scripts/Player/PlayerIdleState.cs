using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerIdleState :PlayerBaseState
{
    
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("entrei no idle state");
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.TrocarState(player.walkState);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            player.TrocarState(player.jumpState);
        }

    }
  
}
