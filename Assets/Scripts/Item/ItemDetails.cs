using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ItemDetails
{
//编号
    public int itemCode;

    public ItemType itemType;

    public string itemDescription;

    public Sprite itemSprite;

    public string itemLongDescription;

    public short itemUseGridRadius;

    public float itemUseRadius;

    public bool isStartingItem;

    public bool canBePickUp;

    public bool canBeDropped;

    public bool canBeEaten;

    public bool canBeCarried;


}