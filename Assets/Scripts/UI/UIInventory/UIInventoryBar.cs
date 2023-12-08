using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    [SerializeField] private Sprite blankSprite;
    [SerializeField] private UIInventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventoryDraggedItem;


    private void OnEnable()
    {
        EventHandler.InventoryUpdateEvent += InventoryUpdate;
    }

    private void OnDisable()
    {
        EventHandler.InventoryUpdateEvent -= InventoryUpdate;
    }

    private void InventoryUpdate(InventoryLocation inventoryLocation, List<InventoryItem> inventoryItems)
    {
        if (InventoryLocation.Player == inventoryLocation)
        {
            CleanInventorySlot();
            var itemsCount = inventoryItems.Count;
            if (inventorySlots.Length <= 0 || itemsCount <= 0)
            {
                return;
            }

            for (var i = 0; i < inventorySlots.Length; i++)
            {
                if (i < itemsCount)
                {
                    var uiInventorySlot = inventorySlots[i];
                    var item = inventoryItems[i];
                    var itemDetails = InventoryManager.Instance.GetItemDetails(item.itemCode);
                    uiInventorySlot.inventorySlotImage.sprite = itemDetails.itemSprite;
                    uiInventorySlot.textMeshProUGUI.text = item.itemQuantity.ToString();
                    uiInventorySlot.itemDetails = itemDetails;
                    uiInventorySlot.itemQuantity = item.itemQuantity;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void CleanInventorySlot()
    {
        if (inventorySlots is { Length: > 0 })
        {
            foreach (var uiInventorySlot in inventorySlots)
            {
                uiInventorySlot.inventorySlotImage.sprite = blankSprite;
                uiInventorySlot.textMeshProUGUI.text = "";
                uiInventorySlot.itemDetails = null;
                uiInventorySlot.itemQuantity = 0;
            }
        }
    }
}