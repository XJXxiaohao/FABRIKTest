using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrik : MonoBehaviour
{

    public Transform link1;
    public Transform link2;
    public Transform link3;
    public GameObject OriginalPoint;
    public int iteratorTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        iteratorTime = 0;
    }
    private void LateUpdate()
    {
        if (Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position) > 0.1f)
        {

            BackwordStep(transform, new Link(link3), link3.forward);

            BackwordStep(link3, new Link(link2), link2.up);

            BackwordStep(link2, new Link(link1), link1.up);

            ForwardStep(link2.position, new Link(link1), Quaternion.identity, Vector3.zero, link1.up);

            ForwardStep(link3.position, new Link(link2), link1.rotation, -link1.right * 10, link2.up);

            ForwardStep(transform.position, new Link(link3), link2.rotation, -link1.right * 10 - link2.right * 10, link2.forward);

            iteratorTime++;


        }
    }

    public void ButtonMethod()
    {
        //�����target��λ��
        //transform.position = new Vector3(UnityEngine.Random.value * 60 - 30, UnityEngine.Random.value * 60 - 30, UnityEngine.Random.value * 60 - 30);

        //Debug.Log(link3.up.x.ToString() + ", " + link3.up.y.ToString() + ", " + link3.up.z.ToString());


        //BackwordStep(transform, new Link(link3, link3.forward));

        //BackwordStep(link3, new Link(link2, link2.up));

        //BackwordStep(link2, new Link(link1, link1.up));

        //Debug.Log("��������" + Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position));

        //ForwardStep(link2.position, new Link(link1, Vector3.up), Quaternion.identity, Vector3.zero);

        //ForwardStep(link3.position, new Link(link2, link1.up), link1.rotation, -link1.right * 10);

        //ForwardStep(transform.position, new Link(link3, link2.forward), link2.rotation, -link1.right * 10 - link2.right * 10);

        #region ������̲���
        ///**
        // * forwardStep��Ҫ����ʲô����������ȷ��һ��Ŀ��λ�ã�
        // * ����link1��Ŀ��λ����Ȼ��Vector3.zero
        // * Ȼ����Ҫ������ת��Ҳ����link1���link2����ת
        // * ��ת�Ӵ������ǿ���ʹ��ͶӰ��ת��
        // * 
        // */
        //link1.position = OriginalPoint.transform.position;
        //link1.rotation = Quaternion.identity;
        ////����link1����תʹ��link1����link2��Ŀ��λ��
        //Vector3 link1target = link2.position;
        //Vector3 link1ToTarget = link1target - link1.position;
        ////�õ�link1����ת������
        //Vector3 rotateAxis1 = link1.up;
        ////����linkToTarget����תƽ�淨������link1.up����ͶӰ
        //Vector3 temp1 = Vector3.Dot(link1ToTarget, rotateAxis1) / Vector3.Magnitude(rotateAxis1) * rotateAxis1;
        ////�õ�ͶӰ����
        //Vector3 ProjectionOnLink1RotatePlane = link1ToTarget - temp1;
        ////ֱ����ת�غ�
        //link1.Rotate(rotateAxis1, Vector3.SignedAngle(-link1.right, ProjectionOnLink1RotatePlane, rotateAxis1), Space.World);

        ///**
        // * ���洦��link2����ת
        // */
        //link2.position = -link1.right * 10;
        //link2.rotation = link1.rotation;
        ////����link2����תʹ��link2����link3��Ŀ��λ��
        //Vector3 link2target = link3.position;
        //Vector3 link2ToTarget = link2target - link2.position;
        ////�õ�link2����ת������
        //Vector3 rotateAxis2 = link2.up;
        ////����linkToTarget����תƽ�淨������link2.up����ͶӰ
        //Vector3 temp2 = Vector3.Dot(link2ToTarget, rotateAxis2) / Vector3.Magnitude(rotateAxis2) * rotateAxis2;
        ////�õ�ͶӰ����
        //Vector3 ProjectionOnLink2RotatePlane = link2ToTarget - temp2;
        ////ֱ����ת�غ�
        //link2.Rotate(rotateAxis2, Vector3.SignedAngle(-link2.right, ProjectionOnLink2RotatePlane, rotateAxis2), Space.World);

        ///**
        //* ���洦��link3����ת
        //*/
        //link3.position = -link1.right * 10 - link2.right * 10;
        ////ȱ�ٵ���link3����ת
        //link3.rotation = link2.rotation;
        ////����link2����תʹ��link2����link3��Ŀ��λ��
        //Vector3 link3target = transform.position;
        //Vector3 link3ToTarget = link3target - link3.position;
        ////�õ�link3����ת������
        //Vector3 rotateAxis3 = link3.forward;
        ////����linkToTarget����תƽ�淨������link3.forward����ͶӰ
        //Vector3 temp3 = Vector3.Dot(link3ToTarget, rotateAxis3) / Vector3.Magnitude(rotateAxis3) * rotateAxis3;
        ////�õ�ͶӰ����
        //Vector3 ProjectionOnLink3RotatePlane = link3ToTarget - temp3;
        ////ֱ����ת�غ�
        //link3.Rotate(rotateAxis3, Vector3.SignedAngle(-link3.right, ProjectionOnLink3RotatePlane, rotateAxis3), Space.World);
        #endregion

        //Debug.Log("��������" + Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position));

    }

    public void BackwordStep(Transform target, Link link,Vector3 rotateAxis)
    {
        Vector3 linkToTarget = target.position - link.transform.position;
        //����linkToTarget��ƽ�淨������link.up����ͶӰ
        Vector3 temp = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //����linkToTarget��ƽ���ͶӰ
        Vector3 ProjectionOnLink3RotatePlane = linkToTarget - temp;
        //������Ҫ��ת�ĽǶ�
        float angleNeeded = Vector3.SignedAngle(-link.transform.right, ProjectionOnLink3RotatePlane, rotateAxis);

        //���нǶ�����

        //-link.right�������˵�ǰ��������תangleNeeded�Ƕ�
        link.transform.Rotate(rotateAxis, angleNeeded, Space.World);

        link.transform.position = link.transform.right * 10 + target.position;

    }

    public void ForwardStep(Vector3 targetPosition, Link link, Quaternion lastRotation, Vector3 lastPosition,Vector3 rotateAxis)
    {
        link.transform.rotation = lastRotation;
        link.transform.position = lastPosition;

        //ָ��target������
        Vector3 linkToTarget = targetPosition - link.transform.position;
        //����linkToTarget��ƽ�淨������link3.up����ͶӰ
        Vector3 temp = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //����linkToTarget��ƽ���ͶӰ����
        Vector3 ProjectionOnLinkRotatePlane = linkToTarget - temp;
        //-link.right�������˵�ǰ������
        link.transform.Rotate(rotateAxis, Vector3.SignedAngle(-link.transform.right, ProjectionOnLinkRotatePlane, rotateAxis), Space.World);
    }

    public void ResetLinkPosition()
    {
        link1.rotation = Quaternion.identity;
        link2.rotation = Quaternion.identity;
        link3.rotation = Quaternion.identity;

        link1.position = Vector3.zero;
        link2.position = new Vector3(-10, 0, 0);
        link3.position = new Vector3(-20, 0, 0);
    }

    public void Test()
    {
        link3.rotation = link2.rotation;
    }
}
