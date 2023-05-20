using UnityEngine;

public class RotateAroundExample : MonoBehaviour
{
    public Transform pivot; // 绕旋转的中心点
    public float speed = 1.0f; // 旋转速度
     // 旋转轴向量

    void Update()
    {
        transform.RotateAround(transform.GetChild(0).position, transform.forward, speed * Time.deltaTime);
    }
}
