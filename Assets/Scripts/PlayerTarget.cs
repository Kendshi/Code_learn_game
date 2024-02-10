using MG_BlocksEngine2.Environment;
using UnityEngine;

public class PlayerTarget : BE2_TargetObject
{
    public new Transform Transform => transform;

    private PathChecker _pathChecker;

    private void Awake()
    {
        if (!_pathChecker)
        {
            _pathChecker = GetComponentInChildren<PathChecker>();
        }
    }

    public Transform CheckPath()
    {
        Debug.Log($"Check path");
        return _pathChecker.CrateRay();
    }
}
