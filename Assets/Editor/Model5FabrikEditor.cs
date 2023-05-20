using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Model5Fabrik))]
public class Model5FabrikEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Model5Fabrik fabrikWithConstrain = (Model5Fabrik)target;

        if (GUILayout.Button("ButtonMethod1"))
        {
            fabrikWithConstrain.ButtonMethod1();
        }
        if (GUILayout.Button("ButtonMethod2"))
        {
            fabrikWithConstrain.ButtonMethod2();
        }
        if (GUILayout.Button("Reset Link Position"))
        {
            fabrikWithConstrain.ResetLinkPosition();
        }

        if (GUILayout.Button("ArmBackwardStep"))
        {
            fabrikWithConstrain.ArmBackwardStep();
        }

        if (GUILayout.Button("ArmForwardStep"))
        {
            fabrikWithConstrain.ArmForwardStep();
        }

        if (GUILayout.Button("WholeIteration"))
        {
            fabrikWithConstrain.WholeIteration();
        }
    }
}
