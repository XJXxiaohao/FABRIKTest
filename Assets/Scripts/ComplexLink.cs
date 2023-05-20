using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexLink
{
    public ComplexLink(string name, float minAngle, float maxAngle)
    {
        this.name = name;
        this.minAngle = minAngle;
        this.maxAngle = maxAngle;
    }

    public string name;


    public float minAngle;

    public float maxAngle;

   
}
