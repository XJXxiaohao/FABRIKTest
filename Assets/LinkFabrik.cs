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
        //保存连杆的transform信息、旋转轴向量，旋转的最小角度和最大角度
        lowerArmLink = new Link("lowerArmLink", lowerArmTransform, -90f, 90f);
        elbowJointRLink = new Link("elbowJointRLink", elbowJointRTransform, -45f, 45f);

    }
    public void ButtonMethod()
    {
    }
    /// <summary>
    /// 改进FABRIK算法的后向阶段
    /// </summary>
    /// <param name="targetPosition">目标位置</param>
    /// <param name="link">需要旋转的连杆</param>
    /// <param name="rotateAxis">该连杆的旋转轴</param>
    public void BackwordStep(Vector3 startPoint, Vector3 targetPosition, Link link, Vector3 rotateAxis)
    {
        Vector3 linkToTarget = targetPosition - link.transform.position;
        //计算linkToTarget到平面法向量（link.up）的投影
        Vector3 temp1 = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //计算linkToTarget到平面的投影
        Vector3 link2TargetProjection = linkToTarget - temp1;

        Vector3 End2Link= link.transform.position - link.transform.GetChild(0).position;

        Vector3 temp2 = Vector3.Dot(End2Link, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;

        Vector3 End2LinkProjection = End2Link - temp2;


        //计算需要旋转的角度
        float angleNeeded = Vector3.SignedAngle(End2LinkProjection, link2TargetProjection, rotateAxis);
        //进行角度限制
        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);


        //保留lowerArmTransform.GetChild(0)的本地坐标
        Transform t = lowerArmTransform.GetChild(0);
        Vector3 v = t.localPosition;

        //在startPoint新建一个游戏物体
        GameObject g = new GameObject("temp");
        g.transform.position = startPoint;
        //lowerArmTransform.GetChild(0)的父物体设置为g
        t.SetParent(g.transform);
        //lowerArmTransform.GetChild(0)移动到startPoint
        t.localPosition = Vector3.zero;
        //lowerArmTransform的父物体设置为
        lowerArmTransform.SetParent(t);
        //改变lowerArmTransform的位置
        lowerArmTransform.localPosition = -v;
        //恢复原来父子关系
        lowerArmTransform.SetParent(transform);
        t.SetParent(lowerArmTransform);


        //-link.right代表连杆的前进方向。旋转angleNeeded角度
        link.transform.RotateAround(startPoint, rotateAxis, angleNeeded);


    }

    /// <summary>
    /// 改进FABRIK算法的前向阶段
    /// </summary>
    /// <param name="targetPosition">目标位置的坐标</param>
    /// <param name="link">需要旋转的连杆</param>
    /// <param name="lastRotation"></param>
    /// <param name="lastPosition"></param>
    /// <param name="rotateAxis">连杆的旋转轴</param>
    public void ForwardStep(Vector3 targetPosition, Link link, Quaternion lastRotation, Vector3 lastPosition, Vector3 rotateAxis)
    {
        link.transform.rotation = lastRotation;
        link.transform.position = lastPosition;

        //指向target的向量
        Vector3 linkToTarget = targetPosition - link.transform.position;
        //计算linkToTarget到平面法向量（link3.up）的投影
        Vector3 temp = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //计算linkToTarget到平面的投影向量
        Vector3 ProjectionOnLinkRotatePlane = linkToTarget - temp;
        //计算需要旋转的角度
        float angleNeeded = Vector3.SignedAngle(-link.transform.right, ProjectionOnLinkRotatePlane, rotateAxis);
        //进行角度限制
        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);
        //-link.right代表连杆的前进方向
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
        //计算linkToTarget到平面法向量（link.up）的投影
        Vector3 temp1 = Vector3.Dot(link2Target,elbowJointRTransform.right) / Vector3.Magnitude(elbowJointRTransform.right) * elbowJointRTransform.right;
        //计算linkToTarget到平面的投影
        Vector3 link2TargetProjection = link2Target - temp1;

        Vector3 End2Link = lowerArmTransform.transform.position - lowerArmTransform.transform.GetChild(0).position;

        Vector3 temp2 = Vector3.Dot(End2Link, elbowJointRTransform.right) / Vector3.Magnitude(elbowJointRTransform.right) * elbowJointRTransform.right;

        Vector3 End2LinkProjection = End2Link - temp2;



        //计算需要旋转的角度
        float angleNeeded = Vector3.SignedAngle(End2LinkProjection, link2TargetProjection, elbowJointRTransform.right);
        //进行角度限制
        float constrainedAngle = Mathf.Clamp(angleNeeded, lowerArmLink.minAngle, lowerArmLink.maxAngle);


        //保留lowerArmTransform.GetChild(0)的本地坐标
        Transform t = lowerArmTransform.GetChild(0);
        Vector3 v = t.localPosition;

        //在startPoint新建一个游戏物体
        GameObject g = new GameObject("temp");
        g.transform.position = target.position;
        //lowerArmTransform.GetChild(0)的父物体设置为g
        t.SetParent(g.transform);
        //lowerArmTransform.GetChild(0)移动到startPoint
        t.localPosition = Vector3.zero;
        //lowerArmTransform的父物体设置为
        lowerArmTransform.SetParent(t);
        //改变lowerArmTransform的位置
        lowerArmTransform.localPosition = -v;
        //恢复原来父子关系
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
