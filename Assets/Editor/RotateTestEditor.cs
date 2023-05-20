using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RotateTest))]
public class RotateTestEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RotateTest rotateTest = (RotateTest)target;

        if (GUILayout.Button("Action"))
        {
            rotateTest.ButtonMethod();
        }
    }
}
