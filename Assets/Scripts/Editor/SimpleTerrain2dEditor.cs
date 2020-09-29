using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SimpleTerrain2d))]
public class SimpleTerrain2dEditor : Editor
{
    public override void OnInspectorGUI()
    {        
        base.OnInspectorGUI();
        SimpleTerrain2d simpleTerrain2D = (SimpleTerrain2d)target;
        if (GUILayout.Button("Generate"))
        {
            simpleTerrain2D.Generate();            
        }
        if (GUILayout.Button("Reset"))
        {
            simpleTerrain2D.Reset();
        }
    }

}
