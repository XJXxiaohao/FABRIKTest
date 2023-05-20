using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabrikWithConstrain : MonoBehaviour
{
    public Transform link1Transform;
    public Transform link2Transform;
    public Transform link3Transform;
    public GameObject OriginalPoint;
    public int iteratorTime = 0;

    Link link1;
    Link link2;
    Link link3;


    void Awake()
    {
        DefineLinks();
    }
    
    void FixedUpdate()
    {
        iteratorTime = 0;
    }

    void LateUpdate()
    {

        if (Vector3.Distance(-link1Transform.right * 10 - link2Transform.right * 10 - link3Transform.right * 10, transform.position) > 0.1f)
        {
            BackwordStep(transform, link3, link3Transform.forward);

            BackwordStep(this.link3Transform, link2, Vector3.up);

            BackwordStep(this.link2Transform, link1, Vector3.up);

            ForwardStep(this.link2Transform.position, link1, Quaternion.identity, Vector3.zero, Vector3.up);

            ForwardStep(this.link3Transform.position, link2, this.link1Transform.rotation, -this.link1Transform.right * 10, Vector3.up);

            ForwardStep(transform.position, link3, this.link2Transform.rotation, -this.link1Transform.right * 10 - this.link2Transform.right * 10, link2Transform.forward);

            iteratorTime++;

        }
    }

    public void ButtonMethod()
    {
        //�����target��λ��
        //transform.position = new Vector3(UnityEngine.Random.value * 60 - 30, UnityEngine.Random.value * 60 - 30, UnityEngine.Random.value * 60 - 30);

        //Debug.Log(link3.up.x.ToString() + ", " + link3.up.y.ToString() + ", " + link3.up.z.ToString());

        if (link3 == null)
        {
            DefineLinks();
        }



        BackwordStep(transform, link3, link3Transform.forward);

        BackwordStep(link3Transform, link2, link2Transform.up);

        BackwordStep(link2Transform, link1, link1Transform.up);

        //Debug.Log("��������" + Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position));

        ForwardStep(link2Transform.position, link1, Quaternion.identity, Vector3.zero, Vector3.up);

        ForwardStep(link3Transform.position, link2, link1Transform.rotation, -link1Transform.right * 10, Vector3.up);

        ForwardStep(transform.position, link3, link2Transform.rotation, -link1Transform.right * 10 - link2Transform.right * 10, link2Transform.forward);

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

    private void DefineLinks()
    {
        //�������˵�transform��Ϣ����ת����������ת����С�ǶȺ����Ƕ�
        link1 = new Link(link1Transform , -90, 90);
        link2 = new Link(link2Transform, -90, 90);
        link3 = new Link(link3Transform, -90, 90);
    }

    /// <summary>
    /// �Ľ�FABRIK�㷨�ĺ���׶�
    /// </summary>
    /// <param name="target">Ŀ��λ��</param>
    /// <param name="link">��Ҫ��ת������</param>
    /// <param name="rotateAxis">�����˵���ת��</param>
    public void BackwordStep(Transform target, Link link, Vector3 rotateAxis)
    {
        Vector3 linkToTarget = target.position - link.transform.position;
        //����linkToTarget��ƽ�淨������link.up����ͶӰ
        Vector3 temp = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //����linkToTarget��ƽ���ͶӰ
        Vector3 ProjectionOnLink3RotatePlane = linkToTarget - temp;
        //������Ҫ��ת�ĽǶ�
        float angleNeeded = Vector3.SignedAngle(-link.transform.right, ProjectionOnLink3RotatePlane, rotateAxis);
        //���нǶ�����
        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);


        //-link.right�������˵�ǰ��������תangleNeeded�Ƕ�
        link.transform.Rotate(rotateAxis, constrainedAngle, Space.World);

        link.transform.position = link.transform.right * 10 + target.position;

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
        link1Transform.rotation = Quaternion.identity;
        link2Transform.rotation = Quaternion.identity;
        link3Transform.rotation = Quaternion.identity;

        link1Transform.position = Vector3.zero;
        link2Transform.position = new Vector3(-10, 0, 0);
        link3Transform.position = new Vector3(-20, 0, 0);
    }

    public void Test()
    {
        
    }
}
