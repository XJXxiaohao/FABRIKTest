using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointOnCircle : MonoBehaviour
{
    public Transform point;
    public Transform referenceRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = point.position;
        transform.rotation = referenceRotation.rotation;
    }
}
