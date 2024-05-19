using CustomInspector;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerRotationPointer : MonoBehaviour
{
    [SerializeField] private Mesh arrow;
    [SerializeField] private Vector3 arrowRotation = new Vector3(90, 90, 0);
    [SerializeField] private bool showGizmos = true;
    [SerializeField] [HideInInspector] private Vector3 transformRotation;
    
    private void OnDrawGizmos()
    {
        if (Application.isPlaying || !showGizmos) return;

        Gizmos.color = Color.green;
        var angels = transform.rotation.eulerAngles;
        Gizmos.DrawMesh(arrow, transform.position + transform.forward * 3,
            Quaternion.Euler(angels.x + arrowRotation.x, angels.y + arrowRotation.y, angels.z + arrowRotation.z));
    }
#if UNITY_EDITOR
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, transformRotation.y, 0);
    }
#endif

    [HorizontalLine("RotateMethods")]

    [MessageBox("Use only this method to rotate", MessageBoxType.Info)]
    
    [Button(nameof(RotateLeft))]
    [HideField]
    public bool isRotateLeft;
    
    [Button(nameof(RotateRight))]
    [HideField]
    public bool isRotateRight;

    public void RotateRight()
    {
        transform.Rotate(0, 90, 0);
        transformRotation = transform.rotation.eulerAngles;
    }

    public void RotateLeft()
    {
        transform.Rotate(0, -90, 0);
        transformRotation = transform.rotation.eulerAngles;
    }
}
