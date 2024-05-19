using UnityEngine;
using CustomInspector;

public class Platform : MonoBehaviour
{
    [SerializeField] 
    private Transform navPoint;
    
    [Range(1,3)]
    [SerializeField] 
    private int heightLevel;
    
    [HideInInspector]
    [SerializeField]
    private PickableType currentPickable;
    
    public Transform NavPoint => navPoint;
    public int HeightLevel => heightLevel;

    private void OnValidate()
    {
        var currentPosition = transform.position;
        
        switch (heightLevel)
        {
            case 1:
                currentPosition.y = 0;
                transform.position = currentPosition;
                break;
            case 2:
                currentPosition.y = 3;
                transform.position = currentPosition;
                break;
            case 3:
                currentPosition.y = 6;
                transform.position = currentPosition;
                break; 
        }
    }

    public bool IsThisFinish()
    {
        if (GetComponentInParent<LevelSettings>().FinishPlatform == this)
        {
            return true;
        }

        return false;
    }

    [HorizontalLine("Set Start and Finish position")]
    
    [Button(nameof(SetStartPoint))]
    [HideField]
    public bool isSetStartPoint;

    private void SetStartPoint()
    {
        GetComponentInParent<LevelSettings>().SetStartPosition(this);
    }
    
    [Button(nameof(SetFinishPoint))]
    [HideField]
    public bool isSetFinishPoint;

    private void SetFinishPoint()
    {
        GetComponentInParent<LevelSettings>().SetFinishPosition(this);
    }
    
    [Button(nameof(RotateLeft))]
    [HideField]
    public bool isRotateLeft;

    private void RotateLeft()
    {
        FindObjectOfType<PlayerRotationPointer>().RotateLeft();
    }
    
    [Button(nameof(RotateRight))]
    [HideField]
    public bool isRotateRight;

    private void RotateRight()
    {
        FindObjectOfType<PlayerRotationPointer>().RotateRight();
    }
    
    [HorizontalLine("Make Pickable object")]
    public PickableType type; 
    
    [Button(nameof(CreatePickable))]
    [HideField]
    public bool isCreatePickable;

    private void CreatePickable()
    {
        Instantiate(Resources.Load<GameObject>(type.ToString()),navPoint.transform.position, Quaternion.identity);
    }
    
}
