using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace ScriptsJogo3D.StateMachine
{
    public class StateMachine<T> where T : System.Enum
    {

        public Dictionary<T, StateBase> dictionaryStates;
        private StateBase currentState;
        public float timeToStartGame = 1f;

        public StateBase estadoAtual
        {
            get { return currentState; }
        }

        public void Init()
        {
            dictionaryStates = new Dictionary<T, StateBase>();
        }
        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictionaryStates.Add(typeEnum, state);
        }

        public void SwitchState(T state)
        {
            if (currentState != null)
            {
                currentState.OnStateExit();
            }

            currentState = dictionaryStates[state];
            currentState.OnStateEnter();
        }

        public void Update()
        {
            if (currentState != null)
            {
                currentState.OnStateStay();
            }


        }
    }
}