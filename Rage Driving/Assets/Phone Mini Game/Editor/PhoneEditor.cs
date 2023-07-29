using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Phone))]

public class PhoneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Phone phone = (Phone)target;

        if(GUILayout.Button("Activate/Deactivate Phone"))
        {
            phone.ActivateAndDeactivateGame();
        }
    }
}
