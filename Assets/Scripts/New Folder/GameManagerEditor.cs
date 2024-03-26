using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameManager fsm = (GameManager)target;
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
        showFoldout = EditorGUILayout.Foldout(showFoldout, "Estados Disponíveis");

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
