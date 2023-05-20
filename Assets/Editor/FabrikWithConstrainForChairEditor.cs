using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(FabrikWithConstrainForChair))]
public class FabrikWithConstrainForChairEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FabrikWithConstrainForChair fabrikWithConstrain = (FabrikWithConstrainForChair)target;

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
            fabrikWithConstrain.BackwardStep();
        }
        if (GUILayout.Button("ForwardStep"))
        {
            fabrikWithConstrain.ForwardStep();
        }

        if (GUILayout.Button("WholeIteration"))
        {
            fabrikWithConstrain.WholeIteration();
        }
    }


}
