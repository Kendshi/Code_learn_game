using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Scriptable objects/Items")]

public class ItemsRef : ScriptableObject
{
   [SerializeField] private List<Pickables> pickables;

   public Pickables GetObject(PickableType type)
   {
      Debug.Log($"get object");
      return pickables.First(pic => pic.Type == type);
   }

}
