using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Sprite ShopOwnerSprite;
    public Vector3 ShopOwnerScale;
    public GameObject ShopOwnerLocation;
    public GameObject PurchasingSection;
    public SpriteRenderer PurchasingItemDisplay;
    public ShopSlot[] ItemSlots;
    public InventoryItem[] ShopItems;
    private static ShopSlot SelectedShopSlot;

    private int nextSlotIndex = 0;

    private void Start()
    {
        var OwnerSpriteRenderer = ShopOwnerLocation.GetComponent<SpriteRenderer>();
        OwnerSpriteRenderer.sprite = ShopOwnerSprite;
        OwnerSpriteRenderer.transform.localScale = ShopOwnerScale;

        if(ItemSlots.Length>0 && ShopItems.Length > 0)
        {
            for (int i = 0; i < ShopItems.Length; i++)
            {
                if (nextSlotIndex > ItemSlots.Length) break;
                ItemSlots[nextSlotIndex].AddShopItem(ShopItems[i]);
                ItemSlots[nextSlotIndex].Manager = this;
                nextSlotIndex++;
            }
        }
    }

    public void SetShopSelectedItem(ShopSlot slot)
    {
        SelectedShopSlot = slot;
        PurchasingItemDisplay.sprite = slot.Item.Sprite;
        PurchasingSection.SetActive(true);
    }

    public void ClearSelectedItem()
    {
        Debug.Log("Clearing Shop Purchase Area");
        SelectedShopSlot = null;
        PurchasingItemDisplay.sprite = null;
        PurchasingSection.SetActive(false);
    }

    public static void PurchaseSelectedItem()
    {
        SelectedShopSlot.PurchaseItem();
    }
}
