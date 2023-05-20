using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link
{
    public Link(Transform transform, float minAngle, float maxAngle)
    {
        this.transform = transform;
        this.minAngle = minAngle;
        this.maxAngle = maxAngle;
    }

    public Link(Transform transform)
    {
        this.transform = transform;
    }
    public Link(Transform transform, float minAngle, float maxAngle, Vector3 pointer2End, string name)
    {
        this.transform = transform;
        this.minAngle = minAngle;
        this.maxAngle = maxAngle;
        this.point2End = pointer2End;
        this.name = name;   
    }

    public Link(string name, Transform transform, float minAngle, float maxAngle)
    {
        this.name = name;
        this.transform = transform;
        this.minAngle = minAngle;
        this.maxAngle = maxAngle;
    }

    public string name;

    public Transform transform;


    public float minAngle;

    public float maxAngle;

    public Vector3 point2End;

}
