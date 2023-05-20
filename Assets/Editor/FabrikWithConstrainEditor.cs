using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(FabrikWithConstrain))]
public class FabrikWithConstrainEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FabrikWithConstrain fabrikWithConstrain = (FabrikWithConstrain)target;

        if (GUILayout.Button("Action"))
        {
            fabrikWithConstrain.ButtonMethod();
        }

        if (GUILayout.Button("Reset Link Position"))
        {
            fabrikWithConstrain.ResetLinkPosition();
        }

        if (GUILayout.Button("Test"))
        {
            fabrikWithConstrain.Test();
        }
    }
    

}
