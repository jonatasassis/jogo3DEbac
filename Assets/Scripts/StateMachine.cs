using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


namespace Script.StateMachine
{
    public class StateMachine<T> where T : System.Enum
    {

        public Dictionary<T, StateBase> dictionaryStates;
        private StateBase currentState;

        public StateBase estadoAtual
        {
            get
            {
                return currentState;
            }
        }
        public void Init()
        {
            dictionaryStates = new Dictionary<T, StateBase>();
        }
        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictionaryStates.Add(typeEnum, state);

        }


        public void SwitchState(T state,params object[] objs)
        {
            if (currentState != null)
            {
                currentState.onStateExit();

            }
            currentState = dictionaryStates[state];
            currentState.onStateEnter(objs);
        }

        public void Update()
        {
            if (currentState != null)
            {
                currentState.onStateStay();

            }

        }
    }
}
