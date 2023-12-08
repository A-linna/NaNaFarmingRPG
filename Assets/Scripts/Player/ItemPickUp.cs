using System;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();

        if (item != null)
        {
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.ItemCode);
            if (itemDetails.canBePickUp) {
                InventoryManager.Instance.AddItem(InventoryLocation.Player, item, other.gameObject);
            }
        }
    }
}
