using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Model5Fabrik : MonoBehaviour
{
    public Transform ShoulderTransform;
    public Transform UpperArm01Transform;
    public Transform UpperArm02Transform;
    public Transform ElbowLink01Transform;
    public Transform ElbowLink02Transform;
    public Transform LowerArmTransform;
    public Transform CenterOfCircleTransform;
    public Transform CenterOfCircleOriginTransform;

    public GameObject OriginalPoint;
    public int iteratorTime = 0;

    Link ShoulderLink;
    Link UpperArm01Link;
    Link ElbowJoint02Link;
    Link ElbowJoint01Link;
    Link ElbowSwitchLink;
    Link LowerArmLink;
    Link WristLink;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    GameObject g4;
    GameObject g3;
    GameObject g2;
    GameObject g1;
    private void DefineLinks()
    {
        //保存连杆的transform信息、旋转轴向量，旋转的最小角度和最大角度
        ShoulderLink = new Link(ShoulderTransform, -90, 90, ShoulderTransform.GetChild(0).position - ShoulderTransform.position, "ShoulderLink");
        UpperArm01Link = new Link(UpperArm01Transform, -45, 45, UpperArm01Transform.GetChild(0).position - UpperArm01Transform.position, "UpperArm01Link");
        //ElbowSwitchLink = new Link(ElbowSwitchTransform, 0, 0, ElbowSwitchTransform.GetChild(0).position - ElbowSwitchTransform.position, "ElbowSwitchLink");
        ElbowJoint02Link = new Link(ElbowLink02Transform, -30, 0, ElbowLink02Transform.GetChild(0).position - ElbowLink02Transform.position, "ElbowJointRLink");
        LowerArmLink = new Link(LowerArmTransform, -45, 45, LowerArmTransform.GetChild(0).position - LowerArmTransform.position, "LowerArmLink");
        //WristLink = new Link(WristTransform, 0, 0, WristTransform.GetChild(0).position - WristTransform.position, "WristLink");
    }
    float lastdistance = -1.0f;
    public double deltaDistance;
    public void ArmBackwardStep()
    {
        if (ElbowJoint02Link == null)
            DefineLinks();

        // LowerArmGoToStartPoint();

        MoveElbowLink01();

        MovelowerLink();

        CalcError();

        LowerLinkMoveToTarget();

        RotateUpperArmNShoulder();
    }
    public void ArmForwardStep()
    {
        SetUpperLinkToOriginalPosition();

        RotateUpperArmForwardStep();

        Vector3 oldDirection = LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position;

        Vector3 newDirection = transform.position - ElbowLink01Transform.GetChild(0).position;

        ElbowLink02Transform.position = ElbowLink01Transform.GetChild(0).position;

        LowerArmTransform.position = ElbowLink02Transform.GetChild(0).position;

        Vector3 oldDirectionProjection = Project(oldDirection, Vector3.up);

        Vector3 newDirectionProjection = Project(newDirection, Vector3.up);

        float angleNeeded1 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, Vector3.up);

        ElbowLink02Transform.Rotate(Vector3.up, angleNeeded1, Space.World);

        LowerArmTransform.RotateAround(ElbowLink02Transform.position, Vector3.up, angleNeeded1);

        oldDirection = LowerArmTransform.GetChild(0).position - LowerArmTransform.position;

        newDirection = transform.position - LowerArmTransform.position;

        oldDirectionProjection = Project(oldDirection, ElbowLink02Transform.right);

        newDirectionProjection = Project(newDirection, ElbowLink02Transform.right);

        float angleNeeded2 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, ElbowLink02Transform.right);

        LowerArmTransform.Rotate(ElbowLink02Transform.right, angleNeeded2, Space.World);
    }

    private void RotateUpperArmForwardStep()
    {
        Vector3 oldDirection = ElbowLink01Transform.GetChild(0).position - UpperArm01Transform.position;

        Vector3 newDirection = ElbowLink02Transform.position - UpperArm01Transform.position;

        Vector3 oldDirectionProjection = Project(oldDirection, Vector3.up);

        Vector3 newDirectionProjection = Project(newDirection, Vector3.up);

        float angleNeeded1 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, Vector3.up);

        UpperArm01Transform.Rotate(Vector3.up, angleNeeded1, Space.World);

        ShoulderTransform.Rotate(Vector3.up, angleNeeded1, Space.World);

        ElbowLink01Transform.rotation = ShoulderTransform.rotation;

        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;


        oldDirection = ElbowLink01Transform.GetChild(0).position - UpperArm01Transform.position;

        oldDirectionProjection = Project(oldDirection, ShoulderTransform.right);

        newDirection = ElbowLink02Transform.position - UpperArm01Transform.position;

        newDirectionProjection = Project(newDirection, ShoulderTransform.right);

        float angleNeeded2 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, ShoulderTransform.right);

        UpperArm01Transform.Rotate(ShoulderTransform.right, angleNeeded2, Space.World);

        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;
    }

    private void SetUpperLinkToOriginalPosition()
    {
        UpperArm01Transform.position = OriginalPoint.transform.position;

        SetEndPosition2TargetBackwardStep(ShoulderTransform, UpperArm01Transform);

        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;
    }

    private void RotateElbowJoint02InForwardStage()
    {
        Vector3 elbowJoint02ToEndEffector = LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position;

        Vector3 newStartToTargetVector = transform.position - ElbowLink01Transform.GetChild(0).position;

        Vector3 elbowJoint02ToEndEffectorProjection = Project(elbowJoint02ToEndEffector, Vector3.up);

        Vector3 newStartToTargetVectorProjection = Project(newStartToTargetVector, Vector3.up);

        float angleNeeded = Vector3.SignedAngle(elbowJoint02ToEndEffectorProjection, newStartToTargetVectorProjection, Vector3.up);

        ElbowLink02Transform.Rotate(Vector3.up, angleNeeded, Space.World);

        ElbowLink02Transform.position = ElbowLink01Transform.GetChild(0).position;
    }

    private void MoveLink1toOriginalPosition()
    {
        //float link1Lenth = (CenterOfCircleTransform.GetChild(0).position - CenterOfCircleTransform.position).magnitude;

        //Transform t = CenterOfCircleTransform.GetChild(0);
        CenterOfCircleTransform.position = CenterOfCircleOriginTransform.position;
        //t.SetParent(null);
        //t.position = CenterOfCircleTransform.position + (ElbowLink02Transform.position - CenterOfCircleTransform.position).normalized * link1Lenth;
        //t.SetParent(CenterOfCircleTransform);

        ShoulderTransform.position = OriginalPoint.transform.position;

        UpperArm01Transform.position = ShoulderTransform.GetChild(0).position;

        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;
    }

    private void UpperLinkMoveToElbowJoint02()
    {
        Vector3 translateVector = ElbowLink02Transform.position - ElbowLink01Transform.GetChild(0).position;

        ElbowLink01Transform.position += translateVector;

        UpperArm01Transform.position += translateVector;

        ShoulderTransform.position += translateVector;
    }

    private void RotateUpperArmNShoulder()
    {
        //Vector3 originToElbow02 = ElbowLink02Transform.position - OriginalPoint.transform.position;

        //float angleNeeded = Vector3.SignedAngle(, Vector3.up);
        //ShoulderTransform.Rotate(Vector3.up, angleNeeded, Space.World);

        Vector3 oldDirection = UpperArm01Transform.position - ElbowLink01Transform.GetChild(0).position;

        SetEndPosition2TargetBackwardStep(ElbowLink01Transform, ElbowLink02Transform);
        SetEndPosition2TargetBackwardStep(UpperArm01Transform, ElbowLink01Transform);

        Vector3 newDirection = OriginalPoint.transform.position - ElbowLink02Transform.position;

        Vector3 oldDirectionProjection = Project(oldDirection, Vector3.up);

        Vector3 newDirectionProjection = Project(newDirection, Vector3.up);

        float angleNeeded1 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, Vector3.up);

        ElbowLink01Transform.RotateAround(ElbowLink01Transform.GetChild(0).position, Vector3.up, angleNeeded1);

        UpperArm01Transform.rotation = ElbowLink01Transform.rotation;

        SetEndPosition2TargetBackwardStep(UpperArm01Transform, ElbowLink01Transform);

        oldDirection = UpperArm01Transform.position - UpperArm01Transform.GetChild(0).position;

        oldDirectionProjection = Project(oldDirection, ElbowLink01Transform.right);

        newDirection = OriginalPoint.transform.position - UpperArm01Transform.GetChild(0).position;

        newDirectionProjection = Project(newDirection, ElbowLink01Transform.right);

        float angleNeeded2 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, ElbowLink01Transform.right);

        UpperArm01Transform.RotateAround(UpperArm01Transform.GetChild(0).position, ElbowLink01Transform.right, angleNeeded2);

        ShoulderTransform.rotation = ElbowLink01Transform.rotation;

        SetEndPosition2TargetBackwardStep(ShoulderTransform, UpperArm01Transform);

    }

    public void WholeIteration()
    {
        ArmBackwardStep();

        ArmForwardStep();

    }
    private void LowerLinkMoveToTarget()
    {
        /**
         * 利用父子关系转换移动
         *
        //LowerArmTransform.SetParent(transform);

        //LowerArmTransform.localPosition = Vector3.zero;

        //LowerArmTransform.SetParent(null);

        ////记住LowerArmTransform位置
        //GameObject g = new GameObject("temp");
        //g.transform.position = LowerArmTransform.position;

        ////记住ElbowLink02Transform的子物体Transform
        //Transform t = ElbowLink02Transform.GetChild(0);
        ////调换父子关系
        //t.SetParent(g.transform);
        //ElbowLink02Transform.SetParent(t);
        //t.localPosition = Vector3.zero;

        //t.SetParent(null);
        //ElbowLink02Transform.SetParent(null);
        //t.SetParent(ElbowLink02Transform);
         */

        /**
         * 利用translate移动，移不动出现异常
          */
        Vector3 moveDirection = LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position;

        float moveDistance = (transform.position - LowerArmTransform.GetChild(0).position).magnitude;

        //LowerArmTransform.Translate会出问题
        LowerArmTransform.position = moveDirection.normalized * moveDistance + LowerArmTransform.position;

        ElbowLink02Transform.position = moveDirection.normalized * moveDistance + ElbowLink02Transform.position;


    }

    private void CalcError()
    {
        float distance = Vector3.Distance(transform.position, LowerArmTransform.GetChild(0).position);
        Debug.Log("距离是：" + distance);

        if (lastdistance > 0)
        {
            deltaDistance = distance - lastdistance;

        }
        lastdistance = distance;
        Debug.Log("距离差是在Inspector面板");

        Debug.Log("夹角：" + Vector3.Angle(transform.position - LowerArmTransform.GetChild(0).position, LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position));

    }

    private void MovelowerLink()
    {
        LowerArmTransform.position = ElbowLink02Transform.GetChild(0).position;
        LowerArmTransform.rotation = ElbowLink02Transform.rotation;

        Vector3 lowerArmToEndEffector = transform.position - LowerArmTransform.position;

        Vector3 p3 = Project(lowerArmToEndEffector, ElbowLink02Transform.right);

        float angleNeeded2 = Vector3.SignedAngle(LowerArmTransform.forward, p3, ElbowLink02Transform.right);

        LowerArmTransform.Rotate(ElbowLink02Transform.right, angleNeeded2, Space.World);
        LowerArmTransform.position = ElbowLink02Transform.GetChild(0).position;
    }

    private void MoveElbowLink01()
    {
        Vector3 elbow02ToEndEffector = LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position;
        Vector3 p1 = Project(elbow02ToEndEffector, Vector3.up);

        Vector3 elbow02ToTarget = transform.position - ElbowLink02Transform.position;
        Vector3 p2 = Project(elbow02ToTarget, Vector3.up);


        float angleNeeded1 = Vector3.SignedAngle(p1, p2, Vector3.up);

        ElbowLink02Transform.Rotate(Vector3.up, angleNeeded1, Space.World);

        ElbowLink02Transform.position = ElbowLink01Transform.GetChild(0).position;
    }

    Vector3 Project(Vector3 v1, Vector3 axis)
    {
        Vector3 temp = Vector3.Dot(v1, axis) / axis.magnitude * axis;

        return v1 - temp;
    }



    private void Step003()
    {
        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;
        ElbowLink01Transform.rotation = ShoulderTransform.rotation;
    }

    private void Step002()
    {
        UpperArm01Transform.position = ShoulderTransform.GetChild(0).position;
        UpperArm01Transform.rotation = ShoulderTransform.rotation;

        Vector3 UpperArmLink2target = ElbowLink01Transform.position - UpperArm01Transform.position;

        Vector3 temp2 = Vector3.Dot(UpperArmLink2target, UpperArm01Transform.right) / UpperArm01Transform.right.magnitude * UpperArm01Transform.right;

        Vector3 link2targetProjection = UpperArmLink2target - temp2;

        float angleNeeded = Vector3.SignedAngle(UpperArm01Transform.forward, link2targetProjection, UpperArm01Transform.right);

        UpperArm01Transform.Rotate(UpperArm01Transform.right, angleNeeded, Space.World);
    }

    private void Step001()
    {
        ShoulderTransform.position = OriginalPoint.transform.position;
        ShoulderTransform.rotation = Quaternion.identity;

        //Vector3 targetPosition1 = ElbowJoint01Transform.GetChild(0).position;
        //计算link2end投影向量
        //Vector3 Elbow02link2end = ElbowLink02Transform.GetChild(0).position - ElbowLink02Transform.position;

        //Vector3 temp1 = Vector3.Dot(Elbow02link2end, Vector3.up) / Vector3.up.magnitude * Vector3.up;

        //Vector3 Elbow02link2endProjection = Elbow02link2end - temp1;
        //计算link2target投影向量
        Vector3 link2target = UpperArm01Transform.position - ShoulderTransform.position;

        Vector3 temp2 = Vector3.Dot(link2target, Vector3.up) / Vector3.up.magnitude * Vector3.up;

        Vector3 link2targetProjection = link2target - temp2;

        float angleNeeded = Vector3.SignedAngle(ShoulderTransform.forward, link2targetProjection, Vector3.up);

        ShoulderTransform.Rotate(Vector3.up, angleNeeded, Space.World);
    }

    private void UpperArmGoToStartPoint()
    {
        SetEndPosition2TargetBackwardStep(ElbowLink01Transform, ElbowLink02Transform);

        SetEndPosition2TargetBackwardStep(UpperArm01Transform, ElbowLink01Transform);

        SetEndPosition2TargetBackwardStep(ShoulderTransform, UpperArm01Transform);
    }

    private void LowerArmGoToStartPoint()
    {
        SetEndPosition2TargetBackwardStep(LowerArmTransform, transform);

        SetEndPosition2TargetBackwardStep(ElbowLink02Transform, LowerArmTransform);
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
    public void ButtonMethod1()
    {
        //LowerArmGoToStartPoint();
        LowerLinkMoveToTarget();
    }
    public void ButtonMethod2()
    {
        UpperArmGoToStartPoint();

    }
    public void ResetLinkPosition()
    {
        //    Vector3(0, 1.07408142, 0)
        //    Vector3(0, 0.907000005, 0)
        //    Vector3(0, 0.907000005, 0.217239827)
        //    Vector3(-0.182373121, 0.757672071, 0.230680868)
        //    Vector3(0, 0.84267199, 0.235718518)

        ShoulderTransform.position = new Vector3(0, 1.07208133f, 0);
        UpperArm01Transform.position = new Vector3(0, 0.914086163f, 0.0f);
        ElbowLink01Transform.position = new Vector3(0, 0.913596749f, 0.230374947f);
        ElbowLink02Transform.position = new Vector3(-0.182373121f, 0.840672016f, 0.230374962f);
        LowerArmTransform.position = new Vector3(-0.121000051f, 0.840672016f, 0.230374962f);
        CenterOfCircleTransform.position = new Vector3(0, 1.07008135f, 0);

        ShoulderTransform.rotation = Quaternion.identity;
        UpperArm01Transform.rotation = Quaternion.identity;
        ElbowLink01Transform.rotation = Quaternion.identity;
        ElbowLink02Transform.rotation = Quaternion.identity;
        LowerArmTransform.rotation = Quaternion.identity;

    }

    /// <summary>
    /// 画出整个运动链
    /// </summary>
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawLine(ShoulderTransform.position, ShoulderTransform.GetChild(0).position, 3);
        Handles.DrawLine(UpperArm01Transform.position, UpperArm01Transform.GetChild(0).position, 3);
        Handles.color = Color.white;
        //Handles.DrawLine(CenterOfCircleTransform.position, CenterOfCircleTransform.GetChild(0).position, 3);
        Handles.DrawLine(UpperArm01Transform.position, ElbowLink01Transform.GetChild(0).position, 3);
        Handles.color = Color.red;
        Handles.DrawLine(ElbowLink01Transform.position, ElbowLink01Transform.GetChild(0).position, 3);
        Handles.DrawLine(ElbowLink02Transform.position, ElbowLink02Transform.GetChild(0).position, 3);
        Handles.color = Color.white;
        Handles.DrawLine(ElbowLink02Transform.position, LowerArmTransform.GetChild(0).position, 3);
        Handles.color = Color.red;
        Handles.DrawLine(LowerArmTransform.position, LowerArmTransform.GetChild(0).position, 3);
        //Handles.DrawLine(WristTransform.position, WristTransform.GetChild(0).position, 3);

        Handles.color = Color.yellow;
        Handles.DrawLine(ElbowLink01Transform.GetChild(0).position, ElbowLink02Transform.position, 3);


    }

}
