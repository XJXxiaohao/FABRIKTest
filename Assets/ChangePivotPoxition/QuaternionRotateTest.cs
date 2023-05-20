using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotateTest : MonoBehaviour
{
    public Transform target;

    [Obsolete]
    public void Test()
    {
        Vector3 line2Target = target.position - transform.position;
        //����linkToTarget��ƽ�淨������link.up����ͶӰ
        Vector3 temp = Vector3.Dot(line2Target, transform.forward) / Vector3.Magnitude(transform.forward) * transform.forward;
        //����linkToTarget��ƽ���ͶӰ
        Vector3 linkToTargetProjectionOnLinkRotatePlane = line2Target - temp;

        float angle = Vector3.SignedAngle(transform.up, linkToTargetProjectionOnLinkRotatePlane, transform.up);

        transform.RotateAround(transform.GetChild(0).position, transform.forward, angle);



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
