using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 此方法使得机器人的工作空间缩小为一个球面
/// </summary>
public class FabrikWithDOFConstrain : MonoBehaviour
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
    public double deltaDistance;
    public float distance = 1f;
    float lastdistance = -1.0f;
    private void FixedUpdate()
    {
        iteratorTime = 0;
    }
    private void LateUpdate()
    {

        if (Vector3.Distance(transform.position, LowerArmTransform.GetChild(0).position) > 0.0001f)
        {
            WholeIteration();
            iteratorTime++;
            distance = Vector3.Distance(transform.position, LowerArmTransform.GetChild(0).position);
        }
    }
    public void ArmBackwardStep()
    {
        RotateLowerArmNElbow02();
        //CalcError();
        LowerLinkMoveToTarget();
        RotateUpperArmNShoulder();
    }
    public void ArmForwardStep()
    {
        SetUpperLinkToOriginalPosition();
        RotateUpperArmForwardStep();
        RotateLowerArmForwardStep();
    }
    private void RotateLowerArmNElbow02()
    {
        //MoveElbowLink02();
        Vector3 oldDirection = LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position;
        Vector3 oldDirectionProjection = ProjectToPlane(oldDirection, Vector3.up);

        Vector3 newDirection = transform.position - ElbowLink02Transform.position;
        Vector3 newDirectionProjection = ProjectToPlane(newDirection, Vector3.up);


        float angleNeeded1 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, Vector3.up);

        ElbowLink02Transform.Rotate(Vector3.up, angleNeeded1, Space.World);

        ElbowLink02Transform.position = ElbowLink01Transform.GetChild(0).position;
        //MovelowerLink();
        LowerArmTransform.position = ElbowLink02Transform.GetChild(0).position;
        LowerArmTransform.rotation = ElbowLink02Transform.rotation;

        oldDirection = LowerArmTransform.GetChild(0).position - LowerArmTransform.position;

        newDirection = transform.position - LowerArmTransform.position;

        oldDirectionProjection = ProjectToPlane(oldDirection, ElbowLink02Transform.right);

        newDirectionProjection = ProjectToPlane(newDirection, ElbowLink02Transform.right);

        float angleNeeded2 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, ElbowLink02Transform.right);

        LowerArmTransform.Rotate(ElbowLink02Transform.right, angleNeeded2, Space.World);
    }
    private void RotateLowerArmForwardStep()
    {
        Vector3 oldDirection = LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position;

        Vector3 newDirection = transform.position - ElbowLink01Transform.GetChild(0).position;

        ElbowLink02Transform.position = ElbowLink01Transform.GetChild(0).position;

        LowerArmTransform.position = ElbowLink02Transform.GetChild(0).position;

        Vector3 oldDirectionProjection = ProjectToPlane(oldDirection, Vector3.up);

        Vector3 newDirectionProjection = ProjectToPlane(newDirection, Vector3.up);

        float angleNeeded1 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, Vector3.up);

        //Debug.Log("angleNeeded1" + angleNeeded1);

        ElbowLink02Transform.Rotate(Vector3.up, angleNeeded1, Space.World);

        LowerArmTransform.RotateAround(ElbowLink02Transform.position, Vector3.up, angleNeeded1);

        //Debug.Log("Vector3.SignedAngle(ElbowLink01Transform.forward, LowerArmTransform.forward,Vector3.up)" + (Vector3.SignedAngle(ElbowLink01Transform.forward, LowerArmTransform.forward, Vector3.up)).ToString());

        //对ElbowLink02Transform的角度进行限制
        if (Vector3.SignedAngle(ElbowLink01Transform.forward, LowerArmTransform.forward, Vector3.up) < -90)
        {
            ElbowLink02Transform.rotation = ElbowLink01Transform.rotation * Quaternion.Euler(0, -90, 0);
        }
        else if (Vector3.SignedAngle(ElbowLink01Transform.forward, LowerArmTransform.forward, Vector3.up) > 0)
        {
            ElbowLink02Transform.rotation = ElbowLink01Transform.rotation;
        }

        LowerArmTransform.position = ElbowLink02Transform.GetChild(0).position;
        LowerArmTransform.rotation = ElbowLink02Transform.rotation;

        oldDirection = LowerArmTransform.GetChild(0).position - LowerArmTransform.position;

        newDirection = transform.position - LowerArmTransform.position;

        oldDirectionProjection = ProjectToPlane(oldDirection, ElbowLink02Transform.right);

        newDirectionProjection = ProjectToPlane(newDirection, ElbowLink02Transform.right);

        float angleNeeded2 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, ElbowLink02Transform.right);


        LowerArmTransform.Rotate(ElbowLink02Transform.right, angleNeeded2, Space.World);

        //对LowerArmTransform的角度进行限制
        if (Vector3.SignedAngle(LowerArmTransform.forward, ElbowLink02Transform.forward, ElbowLink02Transform.right) < -45)
        {
            LowerArmTransform.rotation = ElbowLink02Transform.rotation;
            LowerArmTransform.rotation = ElbowLink02Transform.rotation * Quaternion.Euler(-45, 0, 0);
        }
        else if (Vector3.SignedAngle(LowerArmTransform.forward, ElbowLink02Transform.forward, ElbowLink02Transform.right) > 45)

        {
            LowerArmTransform.rotation = ElbowLink02Transform.rotation;
            LowerArmTransform.rotation = ElbowLink02Transform.rotation * Quaternion.Euler(45, 0, 0);
        }


    }
    private void RotateUpperArmForwardStep()
    {
        Vector3 oldDirection = ElbowLink01Transform.GetChild(0).position - UpperArm01Transform.position;

        Vector3 newDirection = ElbowLink02Transform.position - UpperArm01Transform.position;

        Vector3 oldDirectionProjection = ProjectToPlane(oldDirection, Vector3.up);

        Vector3 newDirectionProjection = ProjectToPlane(newDirection, Vector3.up);

        float angleNeeded1 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, Vector3.up);
        //这里实际上是在旋转ShoulderArmJoint
        UpperArm01Transform.Rotate(Vector3.up, angleNeeded1, Space.World);
        //这里实际上是在旋转ShoulderArmJoint
        ShoulderTransform.Rotate(Vector3.up, angleNeeded1, Space.World);

        ElbowLink01Transform.rotation = ShoulderTransform.rotation;

        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;

        oldDirection = ElbowLink01Transform.GetChild(0).position - UpperArm01Transform.position;

        oldDirectionProjection = ProjectToPlane(oldDirection, ShoulderTransform.right);

        newDirection = ElbowLink02Transform.position - UpperArm01Transform.position;

        newDirectionProjection = ProjectToPlane(newDirection, ShoulderTransform.right);

        float angleNeeded2 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, ShoulderTransform.right);

        UpperArm01Transform.Rotate(ShoulderTransform.right, angleNeeded2, Space.World);

        //对UpperArm01Transform的角度进行限制
        if (Vector3.SignedAngle(ShoulderTransform.forward, UpperArm01Transform.forward, ShoulderTransform.right) > 45)
        {
            UpperArm01Transform.rotation = ShoulderTransform.rotation;
            UpperArm01Transform.rotation = ShoulderTransform.rotation * Quaternion.Euler(45, 0, 0);
        }
        else if (Vector3.SignedAngle(ShoulderTransform.forward, UpperArm01Transform.forward, ShoulderTransform.right) < -45)
        {
            UpperArm01Transform.rotation = ShoulderTransform.rotation;
            UpperArm01Transform.rotation = ShoulderTransform.rotation * Quaternion.Euler(-45, 0, 0);
        }

        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;
    }
    private void RotateUpperArmNShoulder()
    {
        SetEndPosition2TargetBackwardStep(ElbowLink01Transform, ElbowLink02Transform);
        SetEndPosition2TargetBackwardStep(UpperArm01Transform, ElbowLink01Transform);
        Vector3 oldDirection = UpperArm01Transform.position - ElbowLink01Transform.GetChild(0).position;
        Vector3 newDirection = OriginalPoint.transform.position - ElbowLink02Transform.position;
        Vector3 oldDirectionProjection = ProjectToPlane(oldDirection, Vector3.up);
        Vector3 newDirectionProjection = ProjectToPlane(newDirection, Vector3.up);
        float angleNeeded1 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, Vector3.up);
        ElbowLink01Transform.RotateAround(ElbowLink01Transform.GetChild(0).position, Vector3.up, angleNeeded1);
        UpperArm01Transform.rotation = ElbowLink01Transform.rotation;
        SetEndPosition2TargetBackwardStep(UpperArm01Transform, ElbowLink01Transform);
        oldDirection = UpperArm01Transform.position - UpperArm01Transform.GetChild(0).position;
        oldDirectionProjection = ProjectToPlane(oldDirection, ElbowLink01Transform.right);
        newDirection = OriginalPoint.transform.position - UpperArm01Transform.GetChild(0).position;
        newDirectionProjection = ProjectToPlane(newDirection, ElbowLink01Transform.right);
        float angleNeeded2 = Vector3.SignedAngle(oldDirectionProjection, newDirectionProjection, ElbowLink01Transform.right);
        UpperArm01Transform.RotateAround(UpperArm01Transform.GetChild(0).position, ElbowLink01Transform.right, angleNeeded2);
        ShoulderTransform.rotation = ElbowLink01Transform.rotation;
        SetEndPosition2TargetBackwardStep(ShoulderTransform, UpperArm01Transform);
    }
    private void SetUpperLinkToOriginalPosition()
    {
        UpperArm01Transform.position = OriginalPoint.transform.position;
        SetEndPosition2TargetBackwardStep(ShoulderTransform, UpperArm01Transform);
        ElbowLink01Transform.position = UpperArm01Transform.GetChild(0).position;
    }
    public void WholeIteration()
    {
        ArmBackwardStep();
        ArmForwardStep();
    }
    private void LowerLinkMoveToTarget()
    {
        SetEndPosition2TargetBackwardStep(LowerArmTransform, transform);
        SetEndPosition2TargetBackwardStep(ElbowLink02Transform, LowerArmTransform);
    }
    Vector3 ProjectToPlane(Vector3 v1, Vector3 axis)
    {
        return v1 - Vector3.Dot(v1, axis) / axis.magnitude * axis;
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
        tt.localScale = Vector3.one;
        t.localScale = Vector3.one;
        target.localScale = Vector3.one;
    }
    //=========================================//
    private void CalcError()
    {
        distance = Vector3.Distance(transform.position, LowerArmTransform.GetChild(0).position);
        Debug.Log("距离是：" + distance);
        if (lastdistance > 0) deltaDistance = distance - lastdistance;
        lastdistance = distance;
        Debug.Log("距离差是在Inspector面板");
        Debug.Log("夹角：" + Vector3.Angle(transform.position - LowerArmTransform.GetChild(0).position, LowerArmTransform.GetChild(0).position - ElbowLink02Transform.position));
    }
    public void ResetLinkPosition()
    {
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
    public void TestButtonMethod1()
    {

    }
    public void TestButtonMethod2()
    {

    }
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawLine(ShoulderTransform.position, ShoulderTransform.GetChild(0).position, 3);
        Handles.DrawLine(UpperArm01Transform.position, UpperArm01Transform.GetChild(0).position, 3);
        Handles.color = Color.white;
        Handles.DrawLine(UpperArm01Transform.position + ElbowLink01Transform.GetChild(0).position - ElbowLink01Transform.position, ElbowLink01Transform.GetChild(0).position, 3);
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
