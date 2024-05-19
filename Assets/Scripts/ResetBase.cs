using UnityEngine;

public abstract class ResetBase : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        SavePosition();
    }

    public virtual void ResetObject()
    {
        Debug.Log($"Reset {gameObject.name}");
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    public virtual void SavePosition()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
}
