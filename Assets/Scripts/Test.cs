using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform cube;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckBox(cube.transform.position, new Vector3(5, 5, 5), Quaternion.identity, layer))
        {
            Debug.Log("附近遇到了cube物体");

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(cube.transform.position, new Vector3(10, 10, 10));
    }
}
