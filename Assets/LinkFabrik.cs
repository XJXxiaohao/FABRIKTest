using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinkFabrik : MonoBehaviour
{
    public Transform lowerArmTransform;
    public Transform elbowJointRTransform;
    public Transform target;
    public Transform elbowSwitchTransform;

    Link lowerArmLink;
    Link elbowJointRLink;

    private void DefineLinks()
    {
        //�������˵�transform��Ϣ����ת����������ת����С�ǶȺ����Ƕ�
        lowerArmLink = new Link("lowerArmLink", lowerArmTransform, -90f, 90f);
        elbowJointRLink = new Link("elbowJointRLink", elbowJointRTransform, -45f, 45f);

    }
    public void ButtonMethod()
    {
    }
    /// <summary>
    /// �Ľ�FABRIK�㷨�ĺ���׶�
    /// </summary>
    /// <param name="targetPosition">Ŀ��λ��</param>
    /// <param name="link">��Ҫ��ת������</param>
    /// <param name="rotateAxis">�����˵���ת��</param>
    public void BackwordStep(Vector3 startPoint, Vector3 targetPosition, Link link, Vector3 rotateAxis)
    {
        Vector3 linkToTarget = targetPosition - link.transform.position;
        //����linkToTarget��ƽ�淨������link.up����ͶӰ
        Vector3 temp1 = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //����linkToTarget��ƽ���ͶӰ
        Vector3 link2TargetProjection = linkToTarget - temp1;

        Vector3 End2Link= link.transform.position - link.transform.GetChild(0).position;

        Vector3 temp2 = Vector3.Dot(End2Link, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;

        Vector3 End2LinkProjection = End2Link - temp2;


        //������Ҫ��ת�ĽǶ�
        float angleNeeded = Vector3.SignedAngle(End2LinkProjection, link2TargetProjection, rotateAxis);
        //���нǶ�����
        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);


        //����lowerArmTransform.GetChild(0)�ı�������
        Transform t = lowerArmTransform.GetChild(0);
        Vector3 v = t.localPosition;

        //��startPoint�½�һ����Ϸ����
        GameObject g = new GameObject("temp");
        g.transform.position = startPoint;
        //lowerArmTransform.GetChild(0)�ĸ���������Ϊg
        t.SetParent(g.transform);
        //lowerArmTransform.GetChild(0)�ƶ���startPoint
        t.localPosition = Vector3.zero;
        //lowerArmTransform�ĸ���������Ϊ
        lowerArmTransform.SetParent(t);
        //�ı�lowerArmTransform��λ��
        lowerArmTransform.localPosition = -v;
        //�ָ�ԭ�����ӹ�ϵ
        lowerArmTransform.SetParent(transform);
        t.SetParent(lowerArmTransform);


        //-link.right�������˵�ǰ��������תangleNeeded�Ƕ�
        link.transform.RotateAround(startPoint, rotateAxis, angleNeeded);


    }

    /// <summary>
    /// �Ľ�FABRIK�㷨��ǰ��׶�
    /// </summary>
    /// <param name="targetPosition">Ŀ��λ�õ�����</param>
    /// <param name="link">��Ҫ��ת������</param>
    /// <param name="lastRotation"></param>
    /// <param name="lastPosition"></param>
    /// <param name="rotateAxis">���˵���ת��</param>
    public void ForwardStep(Vector3 targetPosition, Link link, Quaternion lastRotation, Vector3 lastPosition, Vector3 rotateAxis)
    {
        link.transform.rotation = lastRotation;
        link.transform.position = lastPosition;

        //ָ��target������
        Vector3 linkToTarget = targetPosition - link.transform.position;
        //����linkToTarget��ƽ�淨������link3.up����ͶӰ
        Vector3 temp = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //����linkToTarget��ƽ���ͶӰ����
        Vector3 ProjectionOnLinkRotatePlane = linkToTarget - temp;
        //������Ҫ��ת�ĽǶ�
        float angleNeeded = Vector3.SignedAngle(-link.transform.right, ProjectionOnLinkRotatePlane, rotateAxis);
        //���нǶ�����
        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);
        //-link.right�������˵�ǰ������
        link.transform.Rotate(rotateAxis, constrainedAngle, Space.World);
    }

    public void ResetLinkPosition()
    {
        //Vector3(-0.182372868, 0.7729702, 0.230680987);    elbowJointRPosition
        //Vector3(0,0.857970119,0.243428186)                lowerArmPosition

        elbowJointRTransform.position = new Vector3(-0.182372868f, 0.7729702f, 0.230680987f);
        elbowJointRTransform.rotation = Quaternion.identity;
        lowerArmTransform.position = new Vector3(0, 0.857970119f, 0.243428186f);
        lowerArmTransform.rotation = Quaternion.identity;
    }

    public void Test()
    {
        if (lowerArmLink == null)
        {
            DefineLinks();
        }

        Vector3 link2Target = target.position - lowerArmTransform.position;
        //����linkToTarget��ƽ�淨������link.up����ͶӰ
        Vector3 temp1 = Vector3.Dot(link2Target,elbowJointRTransform.right) / Vector3.Magnitude(elbowJointRTransform.right) * elbowJointRTransform.right;
        //����linkToTarget��ƽ���ͶӰ
        Vector3 link2TargetProjection = link2Target - temp1;

        Vector3 End2Link = lowerArmTransform.transform.position - lowerArmTransform.transform.GetChild(0).position;

        Vector3 temp2 = Vector3.Dot(End2Link, elbowJointRTransform.right) / Vector3.Magnitude(elbowJointRTransform.right) * elbowJointRTransform.right;

        Vector3 End2LinkProjection = End2Link - temp2;



        //������Ҫ��ת�ĽǶ�
        float angleNeeded = Vector3.SignedAngle(End2LinkProjection, link2TargetProjection, elbowJointRTransform.right);
        //���нǶ�����
        float constrainedAngle = Mathf.Clamp(angleNeeded, lowerArmLink.minAngle, lowerArmLink.maxAngle);


        //����lowerArmTransform.GetChild(0)�ı�������
        Transform t = lowerArmTransform.GetChild(0);
        Vector3 v = t.localPosition;

        //��startPoint�½�һ����Ϸ����
        GameObject g = new GameObject("temp");
        g.transform.position = target.position;
        //lowerArmTransform.GetChild(0)�ĸ���������Ϊg
        t.SetParent(g.transform);
        //lowerArmTransform.GetChild(0)�ƶ���startPoint
        t.localPosition = Vector3.zero;
        //lowerArmTransform�ĸ���������Ϊ
        lowerArmTransform.SetParent(t);
        //�ı�lowerArmTransform��λ��
        lowerArmTransform.localPosition = -v;
        //�ָ�ԭ�����ӹ�ϵ
        lowerArmTransform.SetParent(transform);
        t.SetParent(lowerArmTransform);

        GameObject.DestroyImmediate(g);

        lowerArmLink.transform.RotateAround(target.position, elbowJointRTransform.right, angleNeeded);
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
