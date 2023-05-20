using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Route : MonoBehaviour
{
    public  float Radius = 0.05f;
    [SerializeField]
    private Transform[] controlPoints;

    private Vector3 gizmosPosition;

    private void OnDrawGizmos()
    {
        for (float t = 0; t < 1; t += 0.02f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                             3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                             3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                             Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, Radius);
        }
        Gizmos.DrawLine(controlPoints[0].position, controlPoints[1].position);

        Gizmos.DrawLine(controlPoints[2].position, controlPoints[3].position);
    }

    /// <summary>
    /// 将自己所有子物体的position信息写入文件中
    /// </summary>
    public void writeChildrenPositionsToFile()
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < transform.childCount; i++)
        {
            stringBuilder.Append(transform.GetChild(i).name
                                 + "   "
                                 + "Vector3("
                                 + transform.GetChild(i).position.x
                                 + ","
                                 + transform.GetChild(i).position.y
                                 + ","
                                 + transform.GetChild(i).position.z
                                 + ")"
            );
            stringBuilder.Append("\n");
        }
        stringBuilder.Append("\n");
        File.AppendAllText("D:\\\\" + "route" + ".txt", stringBuilder.ToString());
    }
}