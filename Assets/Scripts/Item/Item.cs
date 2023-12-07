using UnityEngine;

public class Item : MonoBehaviour
{
   [SerializeField]
   private int itemCode;

   private SpriteRenderer _spriteRenderer;

   public int ItemCode
   {
      get => itemCode;
      set => itemCode = value;
   }

   private void Awake()
   {
      _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
   }

   private void Start()
   {
      Init();
   }

   private void Init()
   {
      if (itemCode !=0)
      {
         var itemDetails = InventoryManager.Instance.GetItemDetails(itemCode);
         if (itemDetails != null)
         {
            if (itemDetails.itemType == ItemType.ReapableScenary)
            {
               gameObject.AddComponent<ItemNudge>();
            }
         }
      }
   }
}
