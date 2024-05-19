using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minClampRotation;
    [SerializeField] private float maxClampRotation;
    [SerializeField] private float distanceFromTarget;
    [SerializeField] private float positionOffset;

    private float _rotationX;
    private float _rotationY;
    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _currentRotation = transform.rotation.eulerAngles;
        SetRotation();
    }

    void Update()
    {
        var newPosition = target.position - _transform.forward * distanceFromTarget;
        newPosition.x += positionOffset;
        _transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);
        
            if (!Input.GetMouseButton(1))
        {
            return;
        }
        
        SetRotation();
    }

    public void SetTarget(Transform newTarget) => target = newTarget;

    private void SetRotation()
    {
        float mouseX = -Input.GetAxis("Mouse X") * speed;
        float mouseY = Input.GetAxis("Mouse Y") * speed;

        _rotationX += mouseY;
        _rotationY += mouseX;

        _rotationX = Mathf.Clamp(_rotationX, minClampRotation, maxClampRotation);

        Vector3 newRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, newRotation, ref _smoothVelocity, 0.3f);
        _transform.localEulerAngles = _currentRotation;
    }
}