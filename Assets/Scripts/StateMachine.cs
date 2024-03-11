using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        NONE
    }

    //chave

    public Dictionary<States, StateBase> dictionaryStates;
    private StateBase currentState;
    public float timeToStartGame =1f;

    private void Awake()
    {
        dictionaryStates = new Dictionary<States, StateBase>();
        dictionaryStates.Add(States.NONE,new StateBase());

        SwitchState(States.NONE);

        Invoke(nameof(StartGame),timeToStartGame);
    }

    private void StartGame()
    {
        SwitchState(States.NONE);
    }

    private void SwitchState(States state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState= dictionaryStates[state];
        currentState.OnStateEnter();
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateStay();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
           // SwitchState(States.NONE);
        }
    }
}
