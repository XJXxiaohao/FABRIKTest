using UnityEngine;
using UnityEngine.Events;

public class FollowChild : MonoBehaviour
{
    public TransformChangedEvent onChildTransformChanged;

    private Vector3 initialOffset;
    private Quaternion initialRotation;

    private void Start()
    {
        var childTransform = transform.GetChild(0);
        initialOffset = transform.position - childTransform.position;
        initialRotation = transform.rotation;

        onChildTransformChanged.AddListener(OnChildTransformChanged);
    }

    private void OnChildTransformChanged(Transform childTransform)
    {
        transform.position = childTransform.position + initialOffset;
        transform.rotation = initialRotation * childTransform.rotation;
    }
}
