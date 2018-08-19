using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemStats : MonoBehaviour {

    [SerializeField]
    private Text weaponStats;

    

    private void OnMouseUp()
    {
        InventoryItem item = GameState.CurrentPlayer.FindItemByImage(GetComponent<Image>().sprite);
        if (item != null)
        {
            weaponStats.text = "Name: " + item.ItemName + "\n" +
                                "Strength: " + item.Strength + "\n" +
                                "Cost: " + item.Cost + "\n" +
                                "Defence: " + item.Defense;
        }
    }
}
