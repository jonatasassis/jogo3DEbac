using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof (FSM))]
public class StateMachineEditor : Editor
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FSM fsm = (FSM)target;
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("State Machine");

        if (fsm.stateMachine == null)
        {
            return;
        }

        if (fsm.stateMachine.estadoAtual != null)
        {
            EditorGUILayout.LabelField("Current State: ", fsm.stateMachine.estadoAtual.ToString());
        }
        showFoldout = EditorGUILayout.Foldout(showFoldout,"Estados Disponíveis");

        if (showFoldout)
        {
            if (fsm.stateMachine.dictionaryStates != null)
            {
                var keys = fsm.stateMachine.dictionaryStates.Keys.ToArray();
                var valores = fsm.stateMachine.dictionaryStates.Values.ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], valores[i]));
                }
            }
           
        }
    }

}
