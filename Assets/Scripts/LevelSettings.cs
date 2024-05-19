using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private Platform playerStartPlatform;
    [SerializeField] private Platform finishPosition;
    [SerializeField] private bool showGizmos = true;
    [SerializeField] private PlayerRotationPointer rotationPointer;

    public Transform StartPoint => playerStartPlatform.NavPoint;
    public Quaternion StartRotation => rotationPointer.transform.rotation;

    public Platform FinishPlatform => finishPosition;

    private void OnDrawGizmos()
    {
        if (Application.isPlaying || !playerStartPlatform || !showGizmos)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawCube(playerStartPlatform.transform.position + Vector3.up, Vector3.one * 2);

        if (!finishPosition) return;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(finishPosition.transform.position + Vector3.up, Vector3.one * 2);
    }

    private void OnValidate()
    {
        if (!rotationPointer)
        {
            rotationPointer = GetComponentInChildren<PlayerRotationPointer>();
        }

        if (!playerStartPlatform) return;

        rotationPointer.transform.position = playerStartPlatform.NavPoint.position;

    }

    public void SetStartPosition(Platform start)
    {
        playerStartPlatform = start;
        rotationPointer.transform.position = playerStartPlatform.NavPoint.position;
    }
    
    public void SetFinishPosition(Platform finish)
    {
        finishPosition = finish;
    }
}
