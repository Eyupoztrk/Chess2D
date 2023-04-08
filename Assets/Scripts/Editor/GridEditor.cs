using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateGrid))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CreateGrid createGrid = (CreateGrid)target;

        if (GUILayout.Button("Create"))
        {
            createGrid.Create();
        }
    }
}
