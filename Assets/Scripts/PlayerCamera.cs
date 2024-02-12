using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minClampRotation;
    [SerializeField] private float maxClampRotation;
    [SerializeField] private float distanceFromTarget;
    [SerializeField] private float positionOffset;
    
    private float rotationX;
    private float rotationY;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity;

    private void Start()
    {
        rotationX = 30;
        rotationY = 0;
        Vector3 newRotation = new Vector3(rotationX, rotationY);
        Vector3 newPosition = target.position - transform.forward * distanceFromTarget;
        newPosition.x += positionOffset; 
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(newRotation);
    }

    void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            return;
        }
        
        float mouseX = Input.GetAxis("Mouse X") * speed;
        float mouseY = Input.GetAxis("Mouse Y") * speed;

        rotationX += mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, minClampRotation, maxClampRotation);
        
        Vector3 newRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, newRotation, ref smoothVelocity, 0.3f);
        transform.localEulerAngles = currentRotation;
        
        Vector3 newPosition = target.position - transform.forward * distanceFromTarget;
        newPosition.x += positionOffset; 
        transform.position = newPosition;
    }
}
