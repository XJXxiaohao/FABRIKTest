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
        //随机化target的位置
        //transform.position = new Vector3(UnityEngine.Random.value * 60 - 30, UnityEngine.Random.value * 60 - 30, UnityEngine.Random.value * 60 - 30);

        //Debug.Log(link3.up.x.ToString() + ", " + link3.up.y.ToString() + ", " + link3.up.z.ToString());


        //BackwordStep(transform, new Link(link3, link3.forward));

        //BackwordStep(link3, new Link(link2, link2.up));

        //BackwordStep(link2, new Link(link1, link1.up));

        //Debug.Log("后向步骤误差：" + Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position));

        //ForwardStep(link2.position, new Link(link1, Vector3.up), Quaternion.identity, Vector3.zero);

        //ForwardStep(link3.position, new Link(link2, link1.up), link1.rotation, -link1.right * 10);

        //ForwardStep(transform.position, new Link(link3, link2.forward), link2.rotation, -link1.right * 10 - link2.right * 10);

        #region 面向过程步骤
        ///**
        // * forwardStep需要的是什么，我们首先确定一个目标位置：
        // * 比如link1的目标位置显然是Vector3.zero
        // * 然后需要调整旋转，也就是link1相对link2的旋转
        // * 旋转从处理我们可以使用投影旋转法
        // * 
        // */
        //link1.position = OriginalPoint.transform.position;
        //link1.rotation = Quaternion.identity;
        ////调整link1的旋转使得link1朝向link2的目标位置
        //Vector3 link1target = link2.position;
        //Vector3 link1ToTarget = link1target - link1.position;
        ////拿到link1的旋转轴向量
        //Vector3 rotateAxis1 = link1.up;
        ////计算linkToTarget到旋转平面法向量（link1.up）的投影
        //Vector3 temp1 = Vector3.Dot(link1ToTarget, rotateAxis1) / Vector3.Magnitude(rotateAxis1) * rotateAxis1;
        ////得到投影向量
        //Vector3 ProjectionOnLink1RotatePlane = link1ToTarget - temp1;
        ////直接旋转重合
        //link1.Rotate(rotateAxis1, Vector3.SignedAngle(-link1.right, ProjectionOnLink1RotatePlane, rotateAxis1), Space.World);

        ///**
        // * 下面处理link2的旋转
        // */
        //link2.position = -link1.right * 10;
        //link2.rotation = link1.rotation;
        ////调整link2的旋转使得link2朝向link3的目标位置
        //Vector3 link2target = link3.position;
        //Vector3 link2ToTarget = link2target - link2.position;
        ////拿到link2的旋转轴向量
        //Vector3 rotateAxis2 = link2.up;
        ////计算linkToTarget到旋转平面法向量（link2.up）的投影
        //Vector3 temp2 = Vector3.Dot(link2ToTarget, rotateAxis2) / Vector3.Magnitude(rotateAxis2) * rotateAxis2;
        ////得到投影向量
        //Vector3 ProjectionOnLink2RotatePlane = link2ToTarget - temp2;
        ////直接旋转重合
        //link2.Rotate(rotateAxis2, Vector3.SignedAngle(-link2.right, ProjectionOnLink2RotatePlane, rotateAxis2), Space.World);

        ///**
        //* 下面处理link3的旋转
        //*/
        //link3.position = -link1.right * 10 - link2.right * 10;
        ////缺少调整link3的旋转
        //link3.rotation = link2.rotation;
        ////调整link2的旋转使得link2朝向link3的目标位置
        //Vector3 link3target = transform.position;
        //Vector3 link3ToTarget = link3target - link3.position;
        ////拿到link3的旋转轴向量
        //Vector3 rotateAxis3 = link3.forward;
        ////计算linkToTarget到旋转平面法向量（link3.forward）的投影
        //Vector3 temp3 = Vector3.Dot(link3ToTarget, rotateAxis3) / Vector3.Magnitude(rotateAxis3) * rotateAxis3;
        ////得到投影向量
        //Vector3 ProjectionOnLink3RotatePlane = link3ToTarget - temp3;
        ////直接旋转重合
        //link3.Rotate(rotateAxis3, Vector3.SignedAngle(-link3.right, ProjectionOnLink3RotatePlane, rotateAxis3), Space.World);
        #endregion

        //Debug.Log("后向步骤误差：" + Vector3.Distance(-link1.right * 10 - link2.right * 10 - link3.right * 10, transform.position));

    }

    public void BackwordStep(Transform target, Link link,Vector3 rotateAxis)
    {
        Vector3 linkToTarget = target.position - link.transform.position;
        //计算linkToTarget到平面法向量（link.up）的投影
        Vector3 temp = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //计算linkToTarget到平面的投影
        Vector3 ProjectionOnLink3RotatePlane = linkToTarget - temp;
        //计算需要旋转的角度
        float angleNeeded = Vector3.SignedAngle(-link.transform.right, ProjectionOnLink3RotatePlane, rotateAxis);

        //进行角度限制

        //-link.right代表连杆的前进方向。旋转angleNeeded角度
        link.transform.Rotate(rotateAxis, angleNeeded, Space.World);

        link.transform.position = link.transform.right * 10 + target.position;

    }

    public void ForwardStep(Vector3 targetPosition, Link link, Quaternion lastRotation, Vector3 lastPosition,Vector3 rotateAxis)
    {
        link.transform.rotation = lastRotation;
        link.transform.position = lastPosition;

        //指向target的向量
        Vector3 linkToTarget = targetPosition - link.transform.position;
        //计算linkToTarget到平面法向量（link3.up）的投影
        Vector3 temp = Vector3.Dot(linkToTarget, rotateAxis) / Vector3.Magnitude(rotateAxis) * rotateAxis;
        //计算linkToTarget到平面的投影向量
        Vector3 ProjectionOnLinkRotatePlane = linkToTarget - temp;
        //-link.right代表连杆的前进方向
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
