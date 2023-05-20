using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FabrikWithConstrainForSimplifiedChair : MonoBehaviour
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

    public void BackwardStep(Vector3 startPoint, Vector3 targetPosition, Link link, Vector3 rotateAxis, GameObject gameObject)
    {
        GameObject g = gameObject;
        g.transform.position = startPoint;

        Vector3 oldStart2link = targetPosition - WristTransform.GetChild(0).position;
        Vector3 newStart2target = targetPosition - transform.position;

        Vector3 temp1 = Vector3.Dot(oldStart2link, rotateAxis) / rotateAxis.magnitude * rotateAxis;
        Vector3 temp2 = Vector3.Dot(newStart2target, rotateAxis) / rotateAxis.magnitude * rotateAxis;

        Vector3 oldStart2linkProjection = oldStart2link - temp1;
        Vector3 newStart2targetProjection = newStart2target - temp2;

        float angleNeeded = Vector3.SignedAngle(oldStart2linkProjection, newStart2targetProjection, rotateAxis);

        //g.transform.rotation = Quaternion.LookRotation(WristTransform.GetChild(0).position - LowerArmTransform.position);

        g.transform.Rotate(rotateAxis, angleNeeded, Space.World);

        switch (g.name)
        {
            case "g4":
                //设置旋转
                WristTransform.rotation = g.transform.rotation;

                LowerArmTransform.rotation = g.transform.rotation;
                //设置位置
                SetEndPosition2TargetBackwardStep(WristTransform, g.transform);

                SetEndPosition2TargetBackwardStep(LowerArmTransform, WristTransform);
                break;

            case "g3":
                //设置旋转
                ElbowJointRTransform.rotation = g.transform.rotation;

                //设置位置
                SetEndPosition2TargetBackwardStep(ElbowJointRTransform, LowerArmTransform);
                break;
            default:
                break;
        }


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
    GameObject g4;
    GameObject g3;
    GameObject g2;
    GameObject g1;
    public void LowerArmBackwardStep()
    {
        if (WristLink == null)
            DefineLinks();


        if (g4 == null) g4 = new GameObject("link4");

        g4.transform.position = transform.position;

        Vector3 oldStart2link = ElbowJointRTransform.GetChild(0).position - WristTransform.GetChild(0).position;
        Vector3 newStart2target = ElbowJointRTransform.GetChild(0).position - transform.position;

        Vector3 temp1 = Vector3.Dot(oldStart2link, ElbowJointRTransform.right) / ElbowJointRTransform.right.magnitude * ElbowJointRTransform.right;
        Vector3 temp2 = Vector3.Dot(newStart2target, ElbowJointRTransform.right) / ElbowJointRTransform.right.magnitude * ElbowJointRTransform.right;

        Vector3 oldStart2linkProjection = oldStart2link - temp1;
        Vector3 newStart2targetProjection = newStart2target - temp2;

        float angleNeeded = Vector3.SignedAngle(oldStart2linkProjection, newStart2targetProjection, ElbowJointRTransform.right);

        //g.transform.rotation = Quaternion.LookRotation(WristTransform.GetChild(0).position - LowerArmTransform.position);

        g4.transform.Rotate(ElbowJointRTransform.right, angleNeeded, Space.World);

        //设置旋转
        WristTransform.rotation = g4.transform.rotation;

        LowerArmTransform.rotation = g4.transform.rotation;
        //设置位置
        SetEndPosition2TargetBackwardStep(WristTransform, g4.transform);

        SetEndPosition2TargetBackwardStep(LowerArmTransform, WristTransform);


        if (g3 == null) g3 = new GameObject("link3");
        g3.transform.position = LowerArmTransform.position;

        Vector3 oldStart2link_ = ElbowJointRTransform.position - ElbowJointRTransform.GetChild(0).position;
        Vector3 newStart2target_ = ElbowSwitchTransform.GetChild(0).position - LowerArmTransform.position;

        Vector3 temp3 = Vector3.Dot(oldStart2link_, Vector3.up) / Vector3.up.magnitude * Vector3.up;
        Vector3 temp4 = Vector3.Dot(newStart2target_, Vector3.up) / Vector3.up.magnitude * Vector3.up;

        Vector3 oldStart2linkProjection_ = oldStart2link_ - temp3;
        Vector3 newStart2targetProjection_ = newStart2target_ - temp4;

        float angleNeeded_ = Vector3.SignedAngle(oldStart2linkProjection_, newStart2targetProjection_, Vector3.up);
        Debug.Log(angleNeeded_);
        //g.transform.rotation = Quaternion.LookRotation(WristTransform.GetChild(0).position - LowerArmTransform.position);

        g3.transform.Rotate(Vector3.up, angleNeeded_, Space.World);

        //设置旋转
        ElbowJointRTransform.rotation = g3.transform.rotation;

        //设置位置
        SetEndPosition2TargetBackwardStep(ElbowJointRTransform, LowerArmTransform);

    }
    void SetEndPosition2TargetBackwardStep(Transform t, Transform target)
    {
        Transform tt = t.GetChild(0);

        tt.SetParent(null);

        t.SetParent(tt);

        tt.SetParent(target);

        tt.localPosition = Vector3.zero;

        //恢复父子关系

        t.SetParent(null);

        tt.SetParent(t);

    }
    public void LowerArmForwardStep()
    {
        if (WristLink == null)
            DefineLinks();

        ElbowJointRTransform.position = ElbowSwitchTransform.GetChild(0).position;

        Vector3 link2End = ElbowJointRTransform.GetChild(0).position - ElbowJointRTransform.position;
        Vector3 link2Target = LowerArmTransform.position - ElbowJointRTransform.position;

        Vector3 temp3 = Vector3.Dot(link2End, Vector3.up) / Vector3.up.magnitude * Vector3.up;
        Vector3 temp4 = Vector3.Dot(link2Target, Vector3.up) / Vector3.up.magnitude * Vector3.up;

        Vector3 link2EndProjection = link2End - temp3;
        Vector3 link2TargetProjection = link2Target - temp4;

        float angleNeeded = Vector3.SignedAngle(link2EndProjection, link2TargetProjection, Vector3.up);

        ElbowJointRTransform.Rotate(Vector3.up, angleNeeded, Space.World);

        //========================================================

        LowerArmTransform.position = ElbowJointRTransform.GetChild(0).position;
        LowerArmTransform.rotation = ElbowJointRTransform.rotation;

        WristTransform.position = LowerArmTransform.GetChild(0).position;
        WristTransform.rotation = LowerArmTransform.GetChild(0).rotation;
    }

    public void WholeIteration()
    {
        LowerArmBackwardStep();
        LowerArmForwardStep();
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
        Handles.DrawLine(LowerArmTransform.position, WristTransform.GetChild(0).position, 3);
        //Handles.DrawLine(WristTransform.position, WristTransform.GetChild(0).position, 3);
        Handles.DrawLine(transform.position, WristTransform.GetChild(0).position, 3);

        Handles.color = Color.white;
        Handles.DrawLine(ElbowJointRTransform.position, WristTransform.GetChild(0).position, 3);

    }
}
