using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,
                                IPointerEnterHandler, IPointerExitHandler
{
    //主摄像机
    private Camera _mainCamera;
    private Canvas _parentCanvas;
    //库存栏 位置
    private Transform _parentItemTransform;
    private GameObject _draggedItem;
    public Image inventorySlotImage;
    public Image inventorySlotHighlight;
    public TextMeshProUGUI textMeshProUGUI;

    //当前槽的index
    [SerializeField]
    private int slotNumber;

    [SerializeField]
    private GameObject inventoryTextBoxPre;

    [SerializeField]
    private UIInventoryBar inventoryBar;

    [SerializeField]
    private GameObject itemPrefab;
    [HideInInspector]
    public ItemDetails itemDetails;
    [HideInInspector]
    public int itemQuantity;

    //描述文本y轴偏移
    private float _textBoxUpOffset = 50;

    private void Awake()
    {
        _parentCanvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        _parentItemTransform = GameObject.FindWithTag(Tags.ItemsParentTransform).transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //判断当前卡槽是有有值
        if (itemDetails != null)
        {
            //创建对象
            _draggedItem = Instantiate(inventoryBar.inventoryDraggedItem, inventoryBar.transform);
            //设置sprite
            Image image = _draggedItem.GetComponentInChildren<Image>();
            image.sprite = itemDetails.itemSprite;

        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        //跟随鼠标移动
        if (_draggedItem != null)
        {
            _draggedItem.transform.position = Input.mousePosition;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_draggedItem != null)
        {
            Destroy(_draggedItem);

            //当鼠标停留位置也包含一个UIInventoryBar 组件，则是交换2个物品的位置
            GameObject endTargetGameObject = eventData.pointerCurrentRaycast.gameObject;

            if (endTargetGameObject != null &&
                     endTargetGameObject.GetComponent<UIInventorySlot>() != null)
            {
                int endTargetSlotNumber = endTargetGameObject.GetComponent<UIInventorySlot>().slotNumber;
                InventoryManager.Instance.SwapInventoryItem(InventoryLocation.Player, slotNumber, endTargetSlotNumber);
                DestroyInventoryTextBox();
            }
            else
            {
                if (itemDetails.canBeDropped)
                {
                    DropSelectedItemAtMousePosition();
                }
            }

        }
    }

    private void DropSelectedItemAtMousePosition()
    {
        if (itemDetails != null)
        {
            //在鼠标停留的位置 创建实例
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_mainCamera.transform.position.z));
            GameObject itemGameObject = Instantiate(itemPrefab, worldPosition, Quaternion.identity, _parentItemTransform);
            Item item = itemGameObject.GetComponent<Item>();
            item.ItemCode = itemDetails.itemCode;
            SpriteRenderer spriteRenderer = itemGameObject.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = itemDetails.itemSprite;

            //从库存中删除物品
            InventoryManager.Instance.RemoveItem(InventoryLocation.Player, item.ItemCode);

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemQuantity != 0)
        {
            // 实例化物品描述
            inventoryBar.inventoryTextBoxGameObject = Instantiate(inventoryTextBoxPre, transform.position, Quaternion.identity);
            inventoryBar.inventoryTextBoxGameObject.transform.SetParent(_parentCanvas.transform, false);

            UIInventoryTextBox inventoryTextBox = inventoryBar.inventoryTextBoxGameObject.GetComponent<UIInventoryTextBox>();

            //获取物品的描述
            string itemTypeDescription = InventoryManager.Instance.GetItemTypeDescription(itemDetails.itemType);

            // 设置文本
            inventoryTextBox.SetTextBoxTex(itemDetails.itemDescription, itemTypeDescription, "", itemDetails.itemLongDescription, "", "");

            inventoryBar.inventoryTextBoxGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
            inventoryBar.inventoryTextBoxGameObject.transform.position = new Vector3(transform.position.x, transform.position.y + _textBoxUpOffset, transform.position.z);


        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyInventoryTextBox();
    }

    public void DestroyInventoryTextBox()
    {
        if (inventoryBar.inventoryTextBoxGameObject != null)
        {
            Destroy(inventoryBar.inventoryTextBoxGameObject);
        }
    }
}
