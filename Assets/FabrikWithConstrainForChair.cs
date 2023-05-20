using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FabrikWithConstrainForChair : MonoBehaviour
{

    public Transform ShoulderJointTransform;
    public Transform UpperArm01Transform;
    public Transform UpperArm02Transform;
    public Transform ElbowJointLTransform;
    public Transform ElbowSwitchTransform;
    public Transform ElbowJointRTransform;
    public Transform LowerArmTransform;
    public Transform WristTransform;

    public GameObject OriginalPoint;
    public int iteratorTime = 0;

    Link ShoulderLink;
    Link UpperArm01Link;
    Link ElbowJointRLink;
    Link ElbowJointLLink;
    Link ElbowSwitchLink;
    Link LowerArmLink;
    Link WristLink;

    void Awake()
    {
        DefineLinks();
    }

    void Update()
    {
        //if (Vector3.Distance(-link1Transform.right * 10 - link2Transform.right * 10 - link3Transform.right * 10, transform.position) > 0.1f)
        //{
        //    BackwordStep(transform, link3, link3Transform.forward);

        //    BackwordStep(this.link3Transform, link2, Vector3.up);

        //    BackwordStep(this.link2Transform, link1, Vector3.up);

        //    ForwardStep(this.link2Transform.position, link1, Quaternion.identity, Vector3.zero, Vector3.up);

        //    ForwardStep(this.link3Transform.position, link2, this.link1Transform.rotation, -this.link1Transform.right * 10, Vector3.up);

        //    ForwardStep(transform.position, link3, this.link2Transform.rotation, -this.link1Transform.right * 10 - this.link2Transform.right * 10, link2Transform.forward);

        //    iteratorTime++;

        //}
    }

    public void ButtonMethod()
    {
        //if (ElbowJointRLink == null)
        //{
        //    DefineLinks();
        //}

        //BackwardStep(transform, WristLink, WristTransform.forward);

        //BackwardStep(WristTransform, LowerArmLink, LowerArmTransform.right);

        //BackwardStep(LowerArmTransform, ElbowJointRLink, ElbowJointRTransform.up);

        //BackwardStep(ElbowJointRTransform, ElbowSwitchLink, ElbowSwitchTransform.up);

        //BackwardStep(ElbowSwitchTransform, ElbowJointLLink, ElbowJointLTransform.right);

        //BackwardStep(ElbowJointLTransform, UpperArm01Link, UpperArm01Transform.right);

        //BackwardStep(UpperArm01Transform, ShoulderLink, ShoulderJointTransform.up);

        //Debug.Log("后向步骤误差：" + Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position));

        //ForwardStep(UpperArm01Transform.position, ShoulderLink, Quaternion.identity, OriginalPoint.transform.position, ShoulderJointTransform.up);

        //ForwardStep(ElbowJointLTransform.position, UpperArm01Link, ShoulderJointTransform.rotation, ShoulderJointTransform.GetChild(0).transform.position, UpperArm01Transform.right);

        //ForwardStep(ElbowSwitchTransform.position, ElbowJointLLink, UpperArm01Transform.rotation,
        //    ShoulderJointTransform.GetChild(0).transform.position + UpperArm01Transform.GetChild(0).transform.position,
        //    ElbowJointLTransform.right);

        //ForwardStep(ElbowJointLTransform.position, ElbowSwitchLink, ElbowJointRTransform.rotation,
        //    ShoulderJointTransform.GetChild(0).transform.position + UpperArm01Transform.GetChild(0).transform.position + ElbowJointLTransform.GetChild(0).transform.position,
        //    ElbowJointRTransform.right);

        //ForwardStep(LowerArmTransform.position, ElbowJointRLink, ElbowSwitchTransform.rotation,
        //   ShoulderJointTransform.GetChild(0).transform.position
        //   + UpperArm01Transform.GetChild(0).transform.position
        //   + ElbowJointLTransform.GetChild(0).transform.position
        //   + ElbowSwitchTransform.GetChild(0).transform.position,
        //   ElbowJointRTransform.right);

        //ForwardStep(WristTransform.position, LowerArmLink, ElbowJointRTransform.rotation,
        //   ShoulderJointTransform.GetChild(0).transform.position
        //   + UpperArm01Transform.GetChild(0).transform.position
        //   + ElbowJointLTransform.GetChild(0).transform.position
        //   + ElbowSwitchTransform.GetChild(0).transform.position
        //   + ElbowJointRTransform.GetChild(0).transform.position,
        //   LowerArmTransform.right);

        //ForwardStep(transform.position, WristLink, LowerArmTransform.rotation,
        //  ShoulderJointTransform.GetChild(0).transform.position
        //  + UpperArm01Transform.GetChild(0).transform.position
        //  + ElbowJointLTransform.GetChild(0).transform.position
        //  + ElbowSwitchTransform.GetChild(0).transform.position
        //  + ElbowJointRTransform.GetChild(0).transform.position
        //  + LowerArmTransform.GetChild(0).transform.position,
        //  WristTransform.forward);

        //Debug.Log("后向步骤误差：" + Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position));



    }

    private void DefineLinks()
    {
        //保存连杆的transform信息、旋转轴向量，旋转的最小角度和最大角度
        ShoulderLink = new Link(ShoulderJointTransform, -90, 90, ShoulderJointTransform.GetChild(0).position - ShoulderJointTransform.position, "ShoulderLink");
        UpperArm01Link = new Link(UpperArm01Transform, -45, 45, UpperArm01Transform.GetChild(0).position - UpperArm01Transform.position, "UpperArm01Link");
        ElbowJointLLink = new Link(ElbowJointLTransform, 0, 90, ElbowJointLTransform.GetChild(0).position - ElbowJointLTransform.position, "ElbowJointLLink");
        ElbowSwitchLink = new Link(ElbowSwitchTransform, 0, 0, ElbowSwitchTransform.GetChild(0).position - ElbowSwitchTransform.position, "ElbowSwitchLink");
        ElbowJointRLink = new Link(ElbowJointRTransform, -90, 0, ElbowJointRTransform.GetChild(0).position - ElbowJointRTransform.position, "ElbowJointRLink");
        LowerArmLink = new Link(LowerArmTransform, -45, 45, LowerArmTransform.GetChild(0).position - LowerArmTransform.position, "LowerArmLink");
        WristLink = new Link(WristTransform, 0, 0, WristTransform.GetChild(0).position - WristTransform.position, "WristLink");
    }

    public void BackwardStep(Transform target, Link link, Vector3 rotateAxis)
    {
        Vector3 lineToTarget = target.position - link.transform.position;
        //计算linkToTarget到平面法向量（link.up）的投影
        Vector3 temp = Vector3.Dot(lineToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //计算linkToTarget到平面的投影
        Vector3 linkToTargetProjectionOnLinkRotatePlane = lineToTarget - temp;

        Vector3 link2End = link.transform.GetChild(0).position - link.transform.position;
        //计算linkToTarget到平面法向量（link.up）的投影
        Vector3 temp2 = Vector3.Dot(link2End, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //计算linkToTarget到平面的投影
        Vector3 link2EndProjectionOnLinkRotatePlane = link2End - temp2;
        //计算需要旋转的角度
        float angleNeeded = Vector3.SignedAngle(link2EndProjectionOnLinkRotatePlane, linkToTargetProjectionOnLinkRotatePlane, rotateAxis);//如何计算需要旋转的角度
        //进行角度限制
        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);
        //-link.right代表连杆的前进方向。旋转angleNeeded角度


        link.transform.Rotate(link.transform.forward, angleNeeded);//旋转link
        Quaternion q = Quaternion.FromToRotation(link2EndProjectionOnLinkRotatePlane, linkToTargetProjectionOnLinkRotatePlane);//用于旋转link.pointer2End
        Vector3 v = q * link.point2End;

        Debug.Log(q);
        Debug.Log(v);
        link.transform.position = target.position - v;
    }
    public void NormalBackwordStep(Transform target, Link link)
    {
        link.transform.position = target.position + link.point2End.magnitude * (link.transform.position - target.position).normalized;

        Quaternion q = Quaternion.FromToRotation(link.point2End, target.position - link.transform.position);

        link.transform.rotation = q;
    }
    public void NewBackwardStep(Vector3 targetPosition, Transform linkTransform, Link link)
    {
        //手腕关节指向目标位置的向量
        Vector3 lineToTarget = targetPosition - linkTransform.position;
        //向量在旋转轴上的投影
        Vector3 temp = Vector3.Dot(lineToTarget, LowerArmTransform.forward) / Vector3.Magnitude(LowerArmTransform.forward) * LowerArmTransform.forward;
        //向量在旋转面上的投影
        Vector3 lineToTargetProjectionOnLinkRotatePlane = lineToTarget - temp;
        float angleNeeded;
        float constrainedAngle;
        switch (link.name)
        {
            case "WristLink":
                //计算手腕关节up方向旋转到面投影向量需要的角度
                angleNeeded = Vector3.SignedAngle(linkTransform.up, lineToTargetProjectionOnLinkRotatePlane, linkTransform.forward);
                //进行关节角度限制
                constrainedAngle = Mathf.Clamp(angleNeeded, -45, 45);
                break;
            default:
                //计算手腕关节up方向旋转到面投影向量需要的角度
                angleNeeded = Vector3.SignedAngle(linkTransform.up, lineToTargetProjectionOnLinkRotatePlane, linkTransform.forward);
                //进行关节角度限制
                constrainedAngle = Mathf.Clamp(angleNeeded, -45, 45);
                break;
        }

        //旋转手腕关节
        linkTransform.RotateAround(linkTransform.GetChild(0).position, LowerArmTransform.forward, constrainedAngle);
        linkTransform.GetChild(0).RotateAround(linkTransform.GetChild(0).position, LowerArmTransform.forward, constrainedAngle);

        GameObject g = new GameObject();
        g.transform.position = targetPosition;

        linkTransform.SetParent(g.transform);
        linkTransform.localPosition = Vector3.zero;
        linkTransform.SetParent(null);

        //获取link子物体的transform
        Transform t = linkTransform.GetChild(0);
        //调换父子关系
        t.SetParent(null);
        linkTransform.SetParent(t);
        //移动原link子物体
        t.SetParent(g.transform);
        t.localPosition = Vector3.zero;
        t.SetParent(null);
        //恢复原来的link父子关系
        linkTransform.SetParent(null);
        t.SetParent(linkTransform);
        //销毁GameObject g
        GameObject.DestroyImmediate(g.gameObject);
    }
    public void ChangedBackwardStep(Transform rotateStartPoint, Link link, Link previousLink, Vector3 rotateAxis)
    {
        GameObject g = new GameObject("temp");

        g.transform.position = rotateStartPoint.position;

        Transform t = link.transform.GetChild(0);
        //调换父子关系
        t.SetParent(null);
        link.transform.SetParent(t);
        //将link end移动到target位置
        t.SetParent(g.transform);
        t.localPosition = Vector3.zero;
        //将父子关系恢复
        link.transform.SetParent(null);
        t.SetParent(link.transform);

        GameObject.DestroyImmediate(g.gameObject);


        Vector3 end2PreviousLinkEnd = previousLink.transform.GetChild(0).position - link.transform.GetChild(0).position;

        Vector3 temp1 = Vector3.Dot(end2PreviousLinkEnd, rotateAxis) / rotateAxis.magnitude * rotateAxis;

        Vector3 end2TargetProjectionOnRotationPlane = end2PreviousLinkEnd - temp1;

        Vector3 end2Link = link.transform.position - link.transform.GetChild(0).position;

        Vector3 temp2 = Vector3.Dot(end2Link, rotateAxis) / rotateAxis.magnitude * rotateAxis;

        Vector3 end2LinkProjectionOnRotationPlane = end2Link - temp2;

        float angleNeeded = Vector3.SignedAngle(end2LinkProjectionOnRotationPlane, end2TargetProjectionOnRotationPlane, rotateAxis);

        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);

        link.transform.RotateAround(link.transform.GetChild(0).position, rotateAxis, constrainedAngle);//围绕EndPoint旋转
    }
    public void ChangedBackwardStep(Transform rotateStartPoint, Link link, Vector3 originalPoint, Vector3 rotateAxis)
    {
        GameObject g = new GameObject("temp");

        g.transform.position = rotateStartPoint.position;

        Transform t = link.transform.GetChild(0);
        //调换父子关系
        t.SetParent(null);
        link.transform.SetParent(t);
        //将link end移动到target位置
        t.SetParent(g.transform);
        t.localPosition = Vector3.zero;
        //将父子关系恢复
        link.transform.SetParent(null);
        t.SetParent(link.transform);

        GameObject.DestroyImmediate(g.gameObject);


        Vector3 end2PreviousLinkEnd = originalPoint - link.transform.GetChild(0).position;

        Vector3 temp1 = Vector3.Dot(end2PreviousLinkEnd, rotateAxis) / rotateAxis.magnitude * rotateAxis;

        Vector3 end2TargetProjectionOnRotationPlane = end2PreviousLinkEnd - temp1;

        Vector3 end2Link = link.transform.position - link.transform.GetChild(0).position;

        Vector3 temp2 = Vector3.Dot(end2Link, rotateAxis) / rotateAxis.magnitude * rotateAxis;

        Vector3 end2LinkProjectionOnRotationPlane = end2Link - temp2;

        float angleNeeded = Vector3.SignedAngle(end2LinkProjectionOnRotationPlane, end2TargetProjectionOnRotationPlane, rotateAxis);

        link.transform.RotateAround(link.transform.GetChild(0).position, rotateAxis, angleNeeded);//围绕EndPoint旋转
    }
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
        float angleNeeded;
        switch (link.name)
        {
            case "ElbowSwitchLink":
                angleNeeded = Vector3.SignedAngle(-link.transform.right, ProjectionOnLinkRotatePlane, rotateAxis);
                break;
            case "ElbowJointRLink":
                angleNeeded = Vector3.SignedAngle(link.transform.GetChild(0).position - link.transform.position, ProjectionOnLinkRotatePlane, rotateAxis);
                break;
            case "ShoulderLink":
                angleNeeded = Vector3.SignedAngle(link.transform.forward, ProjectionOnLinkRotatePlane, rotateAxis);
                break;
            default:
                angleNeeded = Vector3.SignedAngle(link.transform.forward, ProjectionOnLinkRotatePlane, rotateAxis);
                break;
        }


        //进行角度限制
        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);
        //-link.right代表连杆的前进方向
        link.transform.Rotate(rotateAxis, constrainedAngle, Space.World);
    }
    public void ChangedForwardStep(Vector3 rotateStartPoint, Link link, Link subsequentLink, Vector3 rotateAxis)
    {
        link.transform.position = rotateStartPoint;
        link.transform.rotation = Quaternion.identity;

        Vector3 link2Target = subsequentLink.transform.position - link.transform.position;
        Vector3 temp = Vector3.Dot(link2Target, rotateAxis) / rotateAxis.magnitude * rotateAxis;
        Vector3 link2TargetProjectionOnRotatePlane = link2Target - temp;
        float angleNeeded;
        switch (link.name)
        {
            case "ElbowSwitchLink":
                angleNeeded = Vector3.SignedAngle(-link.transform.right, link2TargetProjectionOnRotatePlane, rotateAxis);
                break;
            default:
                angleNeeded = Vector3.SignedAngle(link.transform.forward, link2TargetProjectionOnRotatePlane, rotateAxis);
                break;
        }

        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);

        link.transform.Rotate(rotateAxis, constrainedAngle, Space.World);

    }
    public void ChangedForwardStep(Vector3 rotateStartPoint, Link previousLink, Link link, Link subsequentLink, Vector3 rotateAxis)
    {
        link.transform.position = rotateStartPoint;
        link.transform.rotation = previousLink.transform.rotation;

        Vector3 link2Target = subsequentLink.transform.position - link.transform.position;
        Vector3 temp = Vector3.Dot(link2Target, rotateAxis) / rotateAxis.magnitude * rotateAxis;
        Vector3 link2TargetProjectionOnRotatePlane = link2Target - temp;
        float angleNeeded;
        switch (link.name)
        {
            case "ElbowSwitchLink":
                angleNeeded = Vector3.SignedAngle(-link.transform.right, link2TargetProjectionOnRotatePlane, rotateAxis);
                break;
            default:
                angleNeeded = Vector3.SignedAngle(link.transform.forward, link2TargetProjectionOnRotatePlane, rotateAxis);
                break;
        }

        float constrainedAngle = Mathf.Clamp(angleNeeded, link.minAngle, link.maxAngle);

        link.transform.Rotate(rotateAxis, constrainedAngle, Space.World);

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

    public void BackwardStep()
    {
        if (WristLink == null)
            DefineLinks();

        // GameObject g = new GameObject("temp");

        // g.transform.position = transform.position;

        // Transform t = WristTransform.GetChild(0);

        // t.SetParent(null);

        // WristTransform.SetParent(t);

        // t.SetParent(g.transform);

        // t.localPosition = Vector3.zero;

        // WristTransform.SetParent(null);

        // t.SetParent(WristTransform);

        // GameObject.DestroyImmediate(g.gameObject);

        // Vector3 link2Target = LowerArmTransform.GetChild(0).position - WristTransform.GetChild(0).position;

        // Vector3 temp1 = Vector3.Dot(link2Target, WristTransform.forward) / WristTransform.forward.magnitude * WristTransform.forward;

        // Vector3 link2TargetProjectionOnRotationPlate = link2Target - temp1;

        // Vector3 end2Wristlink = WristTransform.position - WristTransform.GetChild(0).position;

        // Vector3 temp2 = Vector3.Dot(end2Wristlink, WristTransform.forward) / WristTransform.forward.magnitude * WristTransform.forward;

        // Vector3 end2WristlinktProjectionOnRotationPlate = end2Wristlink - temp2;

        // float angleNeeded = Vector3.SignedAngle(end2WristlinktProjectionOnRotationPlate, link2TargetProjectionOnRotationPlate, WristTransform.forward);

        // WristTransform.RotateAround(WristTransform.GetChild(0).position, WristTransform.forward, angleNeeded);

        ChangedBackwardStep(transform, WristLink, LowerArmLink, LowerArmTransform.forward);

        ChangedBackwardStep(WristTransform, LowerArmLink, ElbowJointRLink, ElbowJointRTransform.right);

        ChangedBackwardStep(LowerArmTransform, ElbowJointRLink, ElbowSwitchLink, ElbowSwitchTransform.up);

        ChangedBackwardStep(ElbowJointRTransform, ElbowSwitchLink, ElbowJointLLink, ElbowJointLTransform.up);

        ChangedBackwardStep(ElbowSwitchTransform, ElbowJointLLink, UpperArm01Link, UpperArm01Transform.right);

        ChangedBackwardStep(ElbowJointLTransform, UpperArm01Link, ShoulderLink, ShoulderJointTransform.right);

        ChangedBackwardStep(UpperArm01Transform, ShoulderLink, Vector3.zero, Vector3.up);



    }

    public void ForwardStep()
    {
        if (WristLink == null)
            DefineLinks();
        //ForwardStep(UpperArm01Transform.GetChild(0).position - UpperArm01Transform.position, ShoulderLink, Quaternion.identity, OriginalPoint.transform.position, Vector3.up);
        //ForwardStep(ElbowJointLTransform.position, UpperArm01Link, ShoulderJointTransform.rotation, ShoulderJointTransform.GetChild(0).position, ShoulderJointTransform.right);
        //// 形成平行四边形的承重结构
        //UpperArm02Transform.rotation = UpperArm01Transform.rotation;
        ////平行四边形外侧的一竖
        //ElbowJointLLink.transform.rotation = ShoulderJointTransform.rotation;
        //ElbowJointLLink.transform.position = UpperArm01Transform.GetChild(0).position;

        //ForwardStep(ElbowJointRTransform.position, ElbowSwitchLink, ElbowJointLTransform.rotation, ElbowJointLTransform.GetChild(0).position, ElbowJointLTransform.up);

        //ForwardStep(LowerArmTransform.position, ElbowJointRLink, ElbowSwitchTransform.rotation, ElbowSwitchTransform.GetChild(0).position, ElbowSwitchTransform.up);

        //ForwardStep(WristTransform.position, LowerArmLink, ElbowJointRTransform.rotation, ElbowJointRTransform.GetChild(0).position, ElbowJointRTransform.right);

        //ForwardStep(transform.position, WristLink, LowerArmTransform.rotation, LowerArmTransform.GetChild(0).position, LowerArmTransform.forward);

        ChangedForwardStep(OriginalPoint.transform.position, ShoulderLink, UpperArm01Link, Vector3.up);

        ChangedForwardStep(ShoulderJointTransform.GetChild(0).position, ShoulderLink, UpperArm01Link, ElbowJointLLink, ShoulderJointTransform.right);

        ElbowJointLLink.transform.rotation = ShoulderJointTransform.rotation;

        ElbowJointLLink.transform.position = UpperArm01Transform.GetChild(0).position;

        ChangedForwardStep(ElbowJointLTransform.GetChild(0).position, ElbowJointLLink, ElbowSwitchLink, ElbowJointRLink, ElbowJointLTransform.up);

        ChangedForwardStep(ElbowSwitchTransform.GetChild(0).position, ElbowSwitchLink, ElbowJointRLink, LowerArmLink, ElbowSwitchTransform.up);

        ChangedForwardStep(ElbowJointRTransform.GetChild(0).position, ElbowJointRLink, LowerArmLink, WristLink, ElbowJointRTransform.right);

        ChangedForwardStep(LowerArmTransform.GetChild(0).position, LowerArmLink, WristLink, new Link(transform), LowerArmTransform.forward);
    }

    public void WholeIteration()
    {
        BackwardStep();
        ForwardStep();
    }


    /// <summary>
    /// 画出整个运动链
    /// </summary>
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
}
