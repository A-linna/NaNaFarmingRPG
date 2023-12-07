using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    public Image inventorySlotImage;
    public Image inventorySlotHighlight;
    public TextMeshProUGUI textMeshProUGUI;

    [HideInInspector] public ItemDetails itemDetails;
    [HideInInspector] public int itemQuantity;
}
