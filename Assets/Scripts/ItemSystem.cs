using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    [HideInInspector] [SerializeField] private GameObject currentItem;
    
    public void PickUpItem (GameObject item)
    {
        if (currentItem)
        {
            RemoveItem();
        }
        
        currentItem = Instantiate(item, spawnPoint.position, Quaternion.identity, spawnPoint);
    }

    private void RemoveItem()
    {
        if (currentItem is null)
            return;
        
        DestroyImmediate(currentItem);
    }


}
