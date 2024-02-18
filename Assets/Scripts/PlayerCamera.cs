using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minClampRotation;
    [SerializeField] private float maxClampRotation;
    [SerializeField] private float distanceFromTarget;
    [SerializeField] private float positionOffset;
    [SerializeField] private InputListener input;
    
    private float _rotationX;
    private float _rotationY;
    private float _mouseX;
    private float _mouseY;
    private bool _canRotate;
    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity;

    private void OnValidate()
    {
        input ??= FindObjectOfType<InputListener>();
    }

    private void OnEnable()
    {
        input.AddListenerFloat(input.XAxis, SetMouseXAxis);
        input.AddListenerFloat(input.YAxis, SetMouseYAxis);
        //input.OnMouseRightButtonDown.AddListener(SetMouseClick1);
    }

    private void Start()
    {
        _rotationX = 30;
        _rotationY = 0;
        Vector3 newRotation = new Vector3(_rotationX, _rotationY);
        Vector3 newPosition = target.position - transform.forward * distanceFromTarget;
        newPosition.x += positionOffset; 
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(newRotation);
    }
    
    void Update()
    {
        if (!Input.GetMouseButton(1)) return;
        
        _rotationX += _mouseY;
        _rotationY += _mouseX;
        
        _rotationX = Mathf.Clamp(_rotationX, minClampRotation, maxClampRotation);
        
        Vector3 newRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, newRotation, ref _smoothVelocity, 0.3f);
        transform.localEulerAngles = _currentRotation;
        
        Vector3 newPosition = target.position - transform.forward * distanceFromTarget;
        newPosition.x += positionOffset; 
        transform.position = newPosition;
    }

    private void OnDisable()
    {
        input.RemoveListenerFloat(input.XAxis, SetMouseXAxis);
        input.RemoveListenerFloat(input.YAxis, SetMouseYAxis);
        input.OnMouseRightButtonDown.RemoveListener(SetMouseClick1);
    }

    private void SetMouseXAxis(float x) => _mouseX = x * speed;

    private void SetMouseYAxis(float y) => _mouseY = y * speed;

    private void SetMouseClick1()
    {
        _rotationX += _mouseY;
        _rotationY += _mouseX;

        _rotationX = Mathf.Clamp(_rotationX, minClampRotation, maxClampRotation);
        
        Vector3 newRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, newRotation, ref _smoothVelocity, 0.3f);
        transform.localEulerAngles = _currentRotation;
        
        Vector3 newPosition = target.position - transform.forward * distanceFromTarget;
        newPosition.x += positionOffset; 
        transform.position = newPosition;
    }
}
