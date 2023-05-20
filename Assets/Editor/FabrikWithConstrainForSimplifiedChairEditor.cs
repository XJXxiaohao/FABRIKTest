using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FabrikWithConstrainForSimplifiedChair))]
public class FabrikWithConstrainForSimplifiedChairEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FabrikWithConstrainForSimplifiedChair fabrikWithConstrain = (FabrikWithConstrainForSimplifiedChair)target;

        if (GUILayout.Button("Action"))
        {
            fabrikWithConstrain.ButtonMethod();
        }

        if (GUILayout.Button("Reset Link Position"))
        {
            fabrikWithConstrain.ResetLinkPosition();
        }

        if (GUILayout.Button("BackwardStep"))
        {
            fabrikWithConstrain.LowerArmBackwardStep();
        }
        if (GUILayout.Button("ForwardStep"))
        {
            fabrikWithConstrain.LowerArmForwardStep();
        }

        if (GUILayout.Button("WholeIteration"))
        {
            fabrikWithConstrain.WholeIteration();
        }
    }


}
