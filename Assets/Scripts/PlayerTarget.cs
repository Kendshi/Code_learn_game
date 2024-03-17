using MG_BlocksEngine2.Environment;
using UnityEngine;

public class PlayerTarget : BE2_TargetObject
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private float wallCheckerHeight = 2;
    [SerializeField] private bool showGizmos = true;
    [SerializeField] private LayerMask platformLayer;

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
        if (Physics.Raycast(transform.position + Vector3.up * wallCheckerHeight, transform.forward, out var hit,  rayDistance, platformLayer))
        {
            return true;
        }

        return false;
    }
    
}
