using UnityEngine;
using CustomInspector;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{
    [SerializeField] 
    private Transform navPoint;

    [Range(1,3)]
    [SerializeField] 
    private int heightLevel;

    [SerializeField]
    private ItemsRef pickablesRefs;
    
    //[HideInInspector]
    [SerializeField]
    private Pickables currentPickable = null;
    [SerializeField]
    private bool isFreeHighEdit;
    public List<Platform> connectedPlatforms = new List<Platform>();

    public Transform NavPoint => navPoint;
    public int HeightLevel => heightLevel;
    public Pickables CurrentPickable => currentPickable;

    private void OnValidate()
    {
        if (isFreeHighEdit) return;

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
    
    [Space2(20)]
    [Button(nameof(CreatePickable))]
    [HideField]
    public bool isCreatePickable;

    private void CreatePickable()
    {
        Debug.Log(currentPickable); 
        if (currentPickable is not null)
            RemovePickable();
 
        currentPickable = Instantiate(pickablesRefs.GetObject(type).gameObject,navPoint.transform.position, Quaternion.identity).GetComponent<Pickables>();
    }
    
    [Button(nameof(RemovePickable))]
    [HideField]
    public bool isRemovePickable;

    public void RemovePickable()
    {
        if (currentPickable == null)
            return;
        
        DestroyImmediate(currentPickable.gameObject);
        currentPickable = null;
    }
    
}
