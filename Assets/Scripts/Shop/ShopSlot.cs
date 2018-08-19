using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : MonoBehaviour {

    public InventoryItem Item;
    public ShopManager Manager;

    public void AddShopItem(InventoryItem item)
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.Sprite;
        spriteRenderer.transform.localScale = item.Scale;
        Item = item;
    }

    public void PurchaseItem()
    {
        GameState.CurrentPlayer.Inventory.Add(Item);
        Item = null;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
        Manager.ClearSelectedItem();
    }

    private void OnMouseDown()
    {
        if (Item != null)
        {
            Manager.SetShopSelectedItem(this);
        }
    }
}
