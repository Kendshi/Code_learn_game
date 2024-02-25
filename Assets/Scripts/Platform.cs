using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform navPoint;
    [Range(1,3)]
    [SerializeField] 
    private int heightLevel;
    

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
}
