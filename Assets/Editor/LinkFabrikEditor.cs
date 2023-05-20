using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LinkFabrik))]
public class LinkFabrikEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LinkFabrik fabrik = (LinkFabrik)target;

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
