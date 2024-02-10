using UnityEngine;

public class PathChecker : MonoBehaviour
{
   [SerializeField] private float distance = 1000f;
   
   public Transform CrateRay()
   {
      Debug.Log($"RAy init");
      if (Physics.Raycast(transform.position, Vector3.down, out var hit,  distance))
      {
         Debug.Log($"RAy hit");
         if (hit.collider.TryGetComponent(out Platform platform))
         {
            return platform.NavPoint;
         }
      }
      Debug.LogError($"Platform not find");
      return hit.collider.transform;
   }
}
