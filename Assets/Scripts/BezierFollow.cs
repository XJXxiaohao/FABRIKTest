using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 BezierPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0;
        //speedModifier = 0.5f;
        coroutineAllowed = true;
    }

    private void Update()
    {
        //if (coroutineAllowed)
        //{
        //    StartCoroutine(GoByTheRoute(routeToGo));
        //}

        GoByTheRoute1(routeToGo);
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            BezierPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.position = BezierPosition;

            yield return new WaitForEndOfFrame();
        }

        tParam = 0;

        routeToGo += 1;//跳转下一路径

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;
    }

    /// <summary>
    /// 依次跟随贝塞尔曲线的路径运动
    /// </summary>
    /// <param name="routeNumber"></param>
    private void GoByTheRoute1(int routeNumber)
    {
        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        tParam += Time.deltaTime * speedModifier;

        BezierPosition = Mathf.Pow(1 - tParam, 3) * p0 +
            3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
            3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
            Mathf.Pow(tParam, 3) * p3;

        transform.position = BezierPosition;

        if (tParam > 1)
        {
            tParam = 0;
            routeToGo++;
            if (routeToGo > routes.Length - 1)
            {
                routeToGo = 0;
            }
        }
    }
}
