using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workingspace : MonoBehaviour
{
    public Transform link1;
    public Transform link2;
    public Transform link3;
    float timeInterval;
    float time;
    public LayerMask layer;
    public float angle1;
    public float angle2;
    public float angle3;

    // Start is called before the first frame update
    void Start()
    {
        timeInterval = 0.05f;//定时任务的时间间隔
        time = timeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            dosomething();
            time = timeInterval;
        }


    }

    //每0.1秒执行
    private void dosomething()
    {
        angle1 = UnityEngine.Random.value * 360.0f;
        angle2 = UnityEngine.Random.value * 360.0f;
        angle3 = UnityEngine.Random.value * 360.0f;

        angle1 = -90.0f + UnityEngine.Random.value * 180.0f;
        angle2 = -90.0f + UnityEngine.Random.value * 180.0f;
        angle3 = -90.0f + UnityEngine.Random.value * 180.0f;

        //if (angle1 > 30f && angle1 <= 180f)
        //{
        //    angle1 = 30f;
        //}
        //else if (angle1 < 330f)
        //{
        //    angle1 = 330f;
        //}

        //if (angle2 > 30f && angle2 <= 180f)
        //{
        //    angle2 = 30f;
        //}
        //else if (angle2 < 330f)
        //{
        //    angle2 = 330f;
        //}

        //if (angle3 > 30f && angle3 <= 180f)
        //{
        //    angle3 = 30f;
        //}
        //else if (angle3 < 330f)
        //{
        //    angle3 = 330f;
        //}

        link2.rotation = Quaternion.identity;
        link1.rotation = Quaternion.identity;

        link1.Rotate(Vector3.up, angle1, Space.World);
        link2.position = -link1.right * 10;
        link2.Rotate(Vector3.up, angle2, Space.World);
        link3.position = -link1.right * 10 - link2.right * 10;
        link3.rotation = link2.rotation;
        link3.Rotate(link2.forward, angle3, Space.World);

        GameObject g1 = GameObject.CreatePrimitive(PrimitiveType.Cube);

        g1.layer = 3;//设置层级
        g1.transform.position = link3.position - link3.right * 10.0f;//位置设置在第三链接的末端

        // 查看是否与其他的ws物体距离过近
        if (Physics.CheckBox(g1.transform.position, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, layer))
        {
            Debug.Log("附件有物体" + layer.value.ToString());
            g1.SetActive(false);
            Destroy(g1);
        }


    }


    private void OnDrawGizmos()
    {

    }
}
