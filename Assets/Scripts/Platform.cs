using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform _navPoint;

    public Transform NavPoint => _navPoint;
}
