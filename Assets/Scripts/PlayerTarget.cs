using MG_BlocksEngine2.Environment;
using UnityEngine;

public class PlayerTarget : BE2_TargetObject
{
    [SerializeField] private float rayDistance = 5f;
    [SerializeField] private float wallCheckerHeight = 2;
    [SerializeField] private bool showGizmos = true;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private ItemSystem itemSystem;

    private PathChecker _pathChecker;

    public PathChecker PathChecker => _pathChecker;

    private void Awake()
    {
        if (!_pathChecker)
        {
            _pathChecker = GetComponentInChildren<PathChecker>();
        }
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;
      
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + Vector3.up * wallCheckerHeight, transform.forward * rayDistance);
    }

    public bool CheckWall()
    {
        return Physics.Raycast(transform.position + Vector3.up * wallCheckerHeight, transform.forward, out var hit,  rayDistance, platformLayer);
    }

    public bool IsNotHigh()
    {
        // Fast check for platform under player
        if (!Physics.Raycast(transform.position, Vector3.down, out var playerPlatform, rayDistance, platformLayer))
            return false;

        // Check if target platform is on the same level
        var _targetPlatform = _pathChecker.GetTargetPlatform();
        var _playerPlatform = playerPlatform.collider.GetComponent<Platform>();
        if (_targetPlatform is null) return false;

        if (_playerPlatform.connectedPlatforms.Contains(_targetPlatform)) return true;
 
        return _targetPlatform.HeightLevel == _playerPlatform.HeightLevel;
    }

    public void PickUpItem(GameObject item)
    {
        itemSystem.PickUpItem(item);
    }    
}
