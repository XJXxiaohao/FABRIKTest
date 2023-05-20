using UnityEditor;
using UnityEngine;

public class NewModelFabrik : MonoBehaviour
{
    public Transform ShoulderTransform;
    public Transform UpperArm01Transform;
    public Transform UpperArm02Transform;
    public Transform ElbowLink01Transform;
    public Transform ElbowLink02Transform;
    public Transform LowerArmTransform;

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
        ElbowJoint02Link = new Link(ElbowLink02Transform, -180, 180, ElbowLink02Transform.GetChild(0).position - ElbowLink02Transform.position, "ElbowJointRLink");
        LowerArmLink = new Link(LowerArmTransform, -45, 45, LowerArmTransform.GetChild(0).position - LowerArmTransform.position, "LowerArmLink");
        //WristLink = new Link(WristTransform, 0, 0, WristTransform.GetChild(0).position - WristTransform.position, "WristLink");
    }
    public void LowerArmBackwardStep()
    {
        if (WristLink == null)
            DefineLinks();

        LowerArmGoToStartPoint();

    }


    public void WholeIteration()
    {
        Vector3 lowerArmLinkToTarget = transform.position - LowerArmTransform.position;

        Vector3 p = Project(lowerArmLinkToTarget, ElbowLink02Transform.right);

        float angleNeeded = Vector3.SignedAngle(LowerArmTransform.forward, p, ElbowLink02Transform.right);

        LowerArmTransform.Rotate(ElbowLink02Transform.right, angleNeeded, Space.World);
    }
   

    Vector3 Project(Vector3 v1, Vector3 axis)
    {
        Vector3 temp = Vector3.Dot(v1, axis) / axis.magnitude * axis;

        return v1 - temp;


    }
    public void LowerArmForwardStep()
    {

    }



    public void UpperArmBackwardStep()
    {
        if (WristLink == null)
            DefineLinks();
        UpperArmGoToStartPoint();

        Step001();

        Step002();

        Step003();
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
        LowerArmGoToStartPoint();

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

        ShoulderTransform.position = new Vector3(0, 1.07408142f, 0);
        UpperArm01Transform.position = new Vector3(0, 0.907000005f, 0);
        ElbowLink01Transform.position = new Vector3(0, 0.907000005f, 0.217239827f);
        ElbowLink02Transform.position = new Vector3(-0.182373121f, 0.757672071f, 0.230680868f);
        LowerArmTransform.position = new Vector3(0, 0.84267199f, 0.235718518f);

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
