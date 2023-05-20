using UnityEngine;

public class RotateAroundExample : MonoBehaviour
{
    public Transform pivot; // ����ת�����ĵ�
    public float speed = 1.0f; // ��ת�ٶ�
     // ��ת������

    void Update()
    {
        transform.RotateAround(transform.GetChild(0).position, transform.forward, speed * Time.deltaTime);
    }
}
