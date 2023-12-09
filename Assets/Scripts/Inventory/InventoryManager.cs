using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    private Dictionary<int, ItemDetails> _itemDetailsMap;

    //不同仓库的 库存信息
    public Dictionary<InventoryLocation, List<InventoryItem>> inventory;

    //库存容量
    public Dictionary<InventoryLocation, int> inventoryCapacity;

    [SerializeField] private SO_ItemList itemList = null;

    protected override void Awake()
    {
        base.Awake();
        InitItemDetailMap();
    }

    public ItemDetails GetItemDetails(int itemCode)
    {
        return _itemDetailsMap.TryGetValue(itemCode, out var itemDetails) ? itemDetails : null;
    }


    public void AddItem(InventoryLocation inventoryLocation, Item item, GameObject destroyGameObject)
    {
        AddItem(inventoryLocation, item);
        Destroy(destroyGameObject);
    }

    /**
        添加库存
        inventoryLocation  存储的仓库
        item
     */
    public void AddItem(InventoryLocation inventoryLocation, Item item)
    {
        int itemCode = item.ItemCode;
        //找到库存仓库
        List<InventoryItem> inventoryItems = inventory[inventoryLocation];
        AddItemToLocation(inventoryLocation, itemCode);
        EventHandler.CallInventoryUpdateEvent(inventoryLocation, inventoryItems);
    }


    /*--------------------------private
                                method-----------------------------------------*/


    private void AddItemToLocation(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryItems = inventory[inventoryLocation];
        var index = inventoryItems.FindIndex(inventoryItem => inventoryItem.itemCode == itemCode);
        //索引为-1 说明不存在
        if (index == -1)
        {
            var item = new InventoryItem
            {
                itemCode = itemCode,
                itemQuantity = 1
            };
            inventoryItems.Add(item);
        }
        else
        {
            //结构体属于值类型 
            var oldItemQuantity = inventoryItems[index].itemQuantity;
            var newInventoryItem = new InventoryItem
            {
                itemCode = itemCode,
                itemQuantity = oldItemQuantity + 1
            };
            inventoryItems[index] = newInventoryItem;
        }
    }


    private void InitItemDetailMap()
    {
        _itemDetailsMap = new Dictionary<int, ItemDetails>();
        foreach (var itemDetail in itemList.itemDetails)
        {
            _itemDetailsMap.Add(itemDetail.itemCode, itemDetail);
        }

        InitInventoryInfo();
    }

    /**
     * 初始库存信息
     */
    private void InitInventoryInfo()
    {
        inventory = new Dictionary<InventoryLocation, List<InventoryItem>>
        {
            { InventoryLocation.Player, new List<InventoryItem>() },
            { InventoryLocation.Chest, new List<InventoryItem>() }
        };
        inventoryCapacity = new Dictionary<InventoryLocation, int>
        {
            { InventoryLocation.Player, Settings.playerInitialInventoryCapacity }
        };
    }

    public void RemoveItem(InventoryLocation player, int itemCode)
    {
        List<InventoryItem> inventoryItems = inventory[player];
        int index = inventoryItems.FindIndex(item => item.itemCode == itemCode);
        InventoryItem inventoryItem = inventoryItems[index];
        int newItemQuantity = inventoryItem.itemQuantity - 1;
        if (newItemQuantity <= 0)
        {
            inventoryItems.RemoveAt(index);
        }
        else
        {
            InventoryItem newInventoryItem = new()
            {
                itemCode = itemCode,
                itemQuantity = newItemQuantity
            };
            inventoryItems[index] = newInventoryItem;
        }
        EventHandler.CallInventoryUpdateEvent(player, inventoryItems);
    }

    //交换2个物品的位置
    public void SwapInventoryItem(InventoryLocation player, int fromItem, int toItem)
    {

        List<InventoryItem> inventoryItems = inventory[player];
        int count = inventoryItems.Count();
        if (fromItem >= count || toItem >= count || fromItem == toItem
            || fromItem < 0 || toItem < 0)
        {
            return;
        }

        InventoryItem inventoryItem = inventoryItems[fromItem];
        InventoryItem targetItem = inventoryItems[toItem];
        inventoryItems[toItem] = inventoryItem;
        inventoryItems[fromItem] = targetItem;
        EventHandler.CallInventoryUpdateEvent(player, inventoryItems);
    }

    //获取物品的描述信息
    public string GetItemTypeDescription(ItemType itemType)
    {
        return itemType switch
        {
            ItemType.BreakingTool => Settings.BreakingTool,
            ItemType.ChoppingTool => Settings.ChoppingTool,
            ItemType.CollectingTool => Settings.CollectingTool,
            ItemType.HoeingTool => Settings.HoeingTool,
            ItemType.ReapingTool => Settings.ReapingTool,
            ItemType.WateringTool => Settings.WateringTool,
            _ => Settings.GetItemTypeDesc(itemType),
        };
    }
}