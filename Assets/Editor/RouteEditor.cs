using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Route))]
public class RouteEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();//����Ĭ��inspector���

        Route route = (Route)target;

        if (GUILayout.Button("write children positions to file"))
        {
            route.writeChildrenPositionsToFile();
        }
    }


}
