using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuaternionRotateTest))]
public class QuaternionRotateTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        QuaternionRotateTest target1 = (QuaternionRotateTest)target;

        if (GUILayout.Button("Rotate"))
        {
            target1.Test();
        }

    }
}
