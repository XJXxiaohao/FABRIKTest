using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(FabrikWithDOFConstrain))]
public class FabrikWithDOFConstrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FabrikWithDOFConstrain fabrikWithConstrain = (FabrikWithDOFConstrain)target;

        if (GUILayout.Button("TestButtonMethod1"))
        {
            fabrikWithConstrain.TestButtonMethod1();
        }
        if (GUILayout.Button("TestButtonMethod2"))
        {
            fabrikWithConstrain.TestButtonMethod2();
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
