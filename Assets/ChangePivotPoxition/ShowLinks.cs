using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShowLinks : MonoBehaviour
{
    public Transform ShoulderJointTransform;
    public Transform UpperArm01Transform;
    public Transform UpperArm02Transform;
    public Transform ElbowJointLTransform;
    public Transform ElbowSwitchTransform;
    public Transform ElbowJointRTransform;
    public Transform LowerArmTransform;
    public Transform WristTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawLine(ShoulderJointTransform.position, ShoulderJointTransform.GetChild(0).position, 3);
        Handles.DrawLine(UpperArm01Transform.position, UpperArm01Transform.GetChild(0).position, 3);
        Handles.DrawLine(ElbowJointLTransform.position, ElbowJointLTransform.GetChild(0).position, 3);
        Handles.DrawLine(ElbowSwitchTransform.position, ElbowSwitchTransform.GetChild(0).position, 3);
        Handles.DrawLine(ElbowJointRTransform.position, ElbowJointRTransform.GetChild(0).position, 3);
        Handles.DrawLine(LowerArmTransform.position, LowerArmTransform.GetChild(0).position, 3);
        Handles.DrawLine(WristTransform.position, WristTransform.GetChild(0).position, 3);
        Handles.DrawLine(transform.position, WristTransform.position, 3);
    }

    public void ResetLinkPosition()
    {
        ShoulderJointTransform.rotation = Quaternion.identity;
        UpperArm01Transform.rotation = Quaternion.identity;
        UpperArm02Transform.rotation = UpperArm01Transform.rotation;
        ElbowJointLTransform.rotation = Quaternion.identity;
        ElbowSwitchTransform.rotation = Quaternion.identity;
        ElbowJointRTransform.rotation = Quaternion.identity;
        LowerArmTransform.rotation = Quaternion.identity;
        WristTransform.rotation = Quaternion.identity;

        ShoulderJointTransform.position = new Vector3(0, 0.167081416f + 0.928f, 0);
        UpperArm01Transform.position = new Vector3(0, 0 + 0.928f, 0);
        UpperArm02Transform.position = new Vector3(0, -0.072f + 0.928f, 0);
        ElbowJointLTransform.position = new Vector3(0, -0.00570183992f + 0.928f, 0.217240021f);
        ElbowSwitchTransform.position = new Vector3(0.140000075f, -0.170599997f + 0.928f, 0.230681106f);
        ElbowJointRTransform.position = new Vector3(-0.182372868f, -0.155029774f + 0.928f, 0.230680987f);
        LowerArmTransform.position = new Vector3(0, -0.0700298548f + 0.928f, 0.243428349f);
        WristTransform.position = new Vector3(-0.121000253f, -0.0400463343f + 0.928f, 0.67084533f);

    }
  
}
