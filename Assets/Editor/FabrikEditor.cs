using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Fabrik))]
public class FabrikEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Fabrik fabrik = (Fabrik)target;

        if (GUILayout.Button("Action"))
        {
            fabrik.ButtonMethod();
        }

        if (GUILayout.Button("Reset Link Position"))
        {
            fabrik.ResetLinkPosition();
        }

        if (GUILayout.Button("Test"))
        {
            fabrik.Test();
        }
    }
    

}
