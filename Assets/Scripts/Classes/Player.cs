using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Entity {
    public List<InventoryItem> Inventory = new List<InventoryItem>();
    public string[] Skills;
    public int Money;

    public void AddInventoryItem(InventoryItem item)
    {
        this.Strength += item.Strength;
        this.Defense += item.Defense;
        Inventory.Add(item);
    }

    public InventoryItem FindItemByImage(Sprite image)
    {
        if (Inventory.Any(x => x.Sprite == image))
        {
            return Inventory[0];//.First(x => x.Sprite == image);
        }
        else return null;
    }
}
