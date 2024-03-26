using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptsJogo3D.Singleton;
using ScriptsJogo3D.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,GAMEPLAY,PAUSE,WIN,LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Iniciar();
    }

    public void Iniciar()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new StateBase());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new StateBase());
        stateMachine.RegisterStates(GameStates.PAUSE, new StateBase());
        stateMachine.RegisterStates(GameStates.WIN, new StateBase());
        stateMachine.RegisterStates(GameStates.LOSE, new StateBase());

        stateMachine.SwitchState(GameStates.INTRO);
    }
}
