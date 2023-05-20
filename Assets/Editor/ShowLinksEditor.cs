using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShowLinks))]
public class ShowLinksEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ShowLinks showLinks = (ShowLinks)target;

        if (GUILayout.Button("ResetLinkPosition"))
        {
            showLinks.ResetLinkPosition();
        }

    }

}
