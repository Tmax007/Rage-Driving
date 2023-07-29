using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Chicken))]
public class ChickenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Chicken chicken = (Chicken)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Hop"))
        {
            chicken.Hop();
        }

        if(GUILayout.Button("Make it run"))
        {
            chicken.MakeChickenRun();
        }

        GUILayout.EndHorizontal();

        
    }
}
