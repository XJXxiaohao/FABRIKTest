using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NewModelFabrik))]
public class NewModelFabrikEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        NewModelFabrik fabrikWithConstrain = (NewModelFabrik)target;

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

        if (GUILayout.Button("LowerArmBackwardStep"))
        {
            fabrikWithConstrain.LowerArmBackwardStep();
        }
        if (GUILayout.Button("UpperArmBackwardStep"))
        {
            fabrikWithConstrain.UpperArmBackwardStep();
        }

        if (GUILayout.Button("LowerArmForwardStep"))
        {
            fabrikWithConstrain.LowerArmForwardStep();
        }

        if (GUILayout.Button("WholeIteration"))
        {
            fabrikWithConstrain.WholeIteration();
        }
    }
}
