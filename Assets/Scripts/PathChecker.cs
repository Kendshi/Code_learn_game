using UnityEngine;

public class PathChecker : MonoBehaviour
{
   [SerializeField] private float rayDistance = 100f;
   [SerializeField] private bool showGizmos = true;
   
   public Platform CrateRay()
   {
      if (Physics.Raycast(transform.position, Vector3.down, out var hit,  rayDistance))
      {
         if (hit.collider.TryGetComponent(out Platform platform))
         {
            return platform;
         }
      }
//      Debug.LogError($"Platform not find");
      return null;
   }

   private void OnDrawGizmos()
   {
      if (!showGizmos) return;
      
      Gizmos.color = Color.blue;
      Gizmos.DrawRay(transform.position, Vector3.down * rayDistance);
   }
}
