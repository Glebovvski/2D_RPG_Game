using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotController : MonoBehaviour {
    

    public static string GetStats(GameObject itemSlot)
    {
        Image itemImage = itemSlot.GetComponent<Image>();
        InventoryItem item = GameState.CurrentPlayer.FindItemByImage(itemImage.sprite);
        if (item != null)
        {
            string stats = "Name: " + item.ItemName + "\n" +
                                "Strength: " + item.Strength + "\n" +
                                "Cost: " + item.Cost + "\n" +
                                "Defence: " + item.Defense;
            return stats;
        }
        else return "";
    }
}
