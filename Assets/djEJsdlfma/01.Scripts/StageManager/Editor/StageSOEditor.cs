using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StageSO))]
public class StageSOEditor : Editor
{
    private SerializedProperty mapData;

    private void OnEnable()
    {
        mapData = serializedObject.FindProperty("mapData");
    }

    public override void OnInspectorGUI()
    {
        for (int i = 0; i < 7; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < 7; j++)
            {
                EditorGUILayout.IntField(mapData.GetArrayElementAtIndex(i * 7 + j).intValue, GUILayout.Width(20), GUILayout.Height(20));
            }
            EditorGUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
