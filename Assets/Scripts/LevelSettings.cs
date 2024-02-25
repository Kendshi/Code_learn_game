using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private Platform playerStartPlatform;
    [SerializeField] private bool showGizmos = true;

    public Transform StartPoint => playerStartPlatform.NavPoint;

    private void OnDrawGizmos()
    {
        if (Application.isPlaying || !playerStartPlatform || !showGizmos)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawCube(playerStartPlatform.transform.position + Vector3.up, Vector3.one * 2);
    }
}
