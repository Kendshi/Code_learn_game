using UnityEngine;
using UnityEngine.Events;

public class InputListener : MonoBehaviour
{
    private float _mouseXAxis;
    private float _mouseYAxis;

    [HideInInspector] public EventFloat XAxis;
    [HideInInspector] public EventFloat YAxis;
    [HideInInspector] public UnityEvent OnMouseRightButtonDown;
    
    private void Update()
    {
        XAxis.Invoke(Input.GetAxis("Mouse X"));
        YAxis.Invoke(Input.GetAxis("Mouse Y"));

        if (Input.GetMouseButtonDown(1))
        {
            OnMouseRightButtonDown.Invoke();
        }
    }

    public void AddListenerFloat(EventFloat inputEvent, UnityAction<float> action)
    {
        inputEvent.AddListener(action);
    }

    public void RemoveListenerFloat(EventFloat inputEvent, UnityAction<float> action)
    {
        inputEvent.RemoveListener(action);
    }

    [System.Serializable]
    public class EventFloat : UnityEvent<float> { }
}
