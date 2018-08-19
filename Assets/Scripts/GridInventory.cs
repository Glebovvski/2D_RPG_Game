using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridInventory : MonoBehaviour {

    [SerializeField]
    private GameObject ItemSlot;

    [SerializeField]
    private Text playerStats;

    //[SerializeField]
    //private Text weaponStats;

    private int amountOfItems;

    public void ShowWeaponStats()
    {
        //GameObject selectedItem = UnityEngine.EventSystems.EventSystem.current.gameObject;
        //InventoryItem item = GameState.CurrentPlayer.FindItemByImage(selectedItem.GetComponent<Image>().sprite);
        //if (item != null)
        //{
        //    weaponStats.text = "Name: " + item.ItemName + "\n" +
        //                        "Strength: " + item.Strength + "\n" +
        //                        "Cost: " + item.Cost + "\n" +
        //                        "Defence: " + item.Defense;
        //}
    }

    private void Awake()
    {
        playerStats.text = "Level: " + GameState.CurrentPlayer.Level + "\n" +
            "Health: " + GameState.CurrentPlayer.Health + "\n" +
            "Strength: " + GameState.CurrentPlayer.Strength + "\n" +
            "Magic: " + GameState.CurrentPlayer.Magic + "\n" +
            "Defence: " + GameState.CurrentPlayer.Defense + "\n" +
            "Damage: " + GameState.CurrentPlayer.Damage + "\n" +
            "Armor: " + GameState.CurrentPlayer.Armor;
    }

    private void Start()
    {
        amountOfItems = Populate();
    }

    private void Update()
    {
        if (GameState.CurrentPlayer.Inventory.Count != amountOfItems)
        {
            amountOfItems = Populate();
        }
    }

    int Populate()
    {
        GameObject newObj;
        int inventoryCount = GameState.CurrentPlayer.Inventory.Count;
        for (int i = 0; i < inventoryCount; i++)
        {
            newObj = Instantiate(ItemSlot, transform);
            if(GameState.CurrentPlayer.Inventory[i] != null)
            {
                newObj.GetComponent<Image>().sprite = GameState.CurrentPlayer.Inventory[i].Sprite;
                //newObj.GetComponent<Button>().onClick.AddListener(ShowWeaponStats);
            }
        }
        return GameState.CurrentPlayer.Inventory.Count;
        
    }
}
