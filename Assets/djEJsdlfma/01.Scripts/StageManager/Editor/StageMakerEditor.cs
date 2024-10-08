using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StageMaker))]
public class StageMakerEditor : Editor
{
    private static Transform p;
    private static string mapName = "";
    private static string boardName = "";

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Tile = 0, Enemy = 1, Spawn = 2, Goal = 3");

        mapName = GUILayout.TextArea(mapName);
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Make Map"))
        {
            StageSO so = ScriptableObject.CreateInstance<StageSO>();

            for (int i = 0; i < 49; i++)
            {
                switch (p.GetChild(i).tag)
                {
                    case "Enemy":
                        so.mapData.Add(1);
                        break;
                    case "Spawn":
                        so.mapData.Add(2);
                        break;
                    case "Goal":
                        so.mapData.Add(3);
                        break;
                    default:
                        so.mapData.Add(0);
                        break;
                }
            }
            EditorUtility.SetDirty(so);
            AssetDatabase.CreateAsset(so, "Assets/Shy/08_SO/Stage/" + mapName + ".asset");
        }

        string mes = "null";
        if (p != null) mes = p.name;
        GUILayout.Label(mes);

        boardName = GUILayout.TextArea(boardName);
        serializedObject.ApplyModifiedProperties();
        if (GUILayout.Button("Board Set"))
        {
            p = GameObject.Find(boardName).transform;
        }


    }
}