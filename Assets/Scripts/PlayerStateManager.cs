using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState estadoAtual;
    public  PlayerIdleState idleState = new PlayerIdleState();
    public PlayerJumpState jumpState = new PlayerJumpState();
    public PlayerWalkState walkState = new PlayerWalkState();

    // Start is called before the first frame update
    void Start()
    {
        estadoAtual = idleState;
        estadoAtual.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        estadoAtual.UpdateState(this);
    }

     public void TrocarState(PlayerBaseState state)
    {
        estadoAtual = state;
        state.EnterState(this);
    }
}
