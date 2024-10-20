using UnityEngine;

public class PathChecker : MonoBehaviour
{
   [SerializeField] private float rayDistance = 100f;
   [SerializeField] private bool showGizmos = true;
   
   public Platform GetTargetPlatform()
   {
      if (Physics.Raycast(transform.position, Vector3.down, out var hit,  rayDistance, LayerMask.GetMask("Platform")))
      {
         Debug.Log($"PathChecker.CreateRay: hit to {hit.collider.name}");
         if (hit.collider.TryGetComponent(out Platform platform))
         {
            return platform;
         }
      }
      return null;
   }

   private void OnDrawGizmos()
   {
      if (!showGizmos) return;
      
      Gizmos.color = Color.blue;
      Gizmos.DrawRay(transform.position, Vector3.down * rayDistance);
   }
}
