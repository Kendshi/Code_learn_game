using UnityEngine;

public class PathChecker : MonoBehaviour
{
   [SerializeField] private float distance = 100f;
   [SerializeField] private bool showGizmos = true;
   
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

   private void OnDrawGizmos()
   {
      if (!showGizmos) return;
      
      Gizmos.color = Color.blue;
      Gizmos.DrawRay(transform.position, Vector3.down * distance);
   }
}
