using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RotateTest : MonoBehaviour
{
    public Transform link;
    public float lastAngle;
    public void ButtonMethod()
    {

        Vector3 axis = Vector3.up;
        // Subtracting localRotation off
        Quaternion rotation = Quaternion.Inverse(transform.localRotation) * transform.localRotation;

        //Limits rotation to a single degree of freedom (along axis)
        Quaternion DOF = Quaternion.FromToRotation(rotation * axis, axis) * rotation;

        // Get offset from last rotation in angle-axis representation
        Quaternion addRotation = DOF * Quaternion.Inverse(Quaternion.identity);
        float addAngle = Quaternion.Angle(Quaternion.identity, addRotation);

        Vector3 secondaryAxis = new Vector3(axis.z, axis.x, axis.y);
        Vector3 cross = Vector3.Cross(secondaryAxis, axis);
        if (Vector3.Dot(addRotation * secondaryAxis, cross) > 0f) addAngle = -addAngle;

        // Clamp to limits
        lastAngle = Mathf.Clamp(lastAngle + addAngle, -30, 30);
        Quaternion limitedRotation = Quaternion.AngleAxis(lastAngle, axis);

        // Add localRotation back on
        transform.localRotation = transform.localRotation * limitedRotation;


    }

    private void Update()
    {
      
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(link.position, 3 * Vector3.up);
        Gizmos.DrawLine(link.position, 3 * Vector3.forward);
        Gizmos.DrawLine(link.position, 3 * Vector3.right);


    }
}
