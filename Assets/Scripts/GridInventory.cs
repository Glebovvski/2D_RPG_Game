using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridInventory : MonoBehaviour {

    [SerializeField]
    private GameObject ItemSlot;
    
    private int amountOfItems;
    
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
        if (GameState.CurrentPlayer.Inventory.Count == 0)
            ItemSlot.SetActive(false);
        else
        {
            ItemSlot.GetComponent<Image>().sprite = GameState.CurrentPlayer.Inventory[0].Sprite;
        }
        GameObject newObj;
        int inventoryCount = GameState.CurrentPlayer.Inventory.Count;
        for (int i = 1; i < inventoryCount; i++)
        {
            newObj = Instantiate(ItemSlot, transform);
            if(GameState.CurrentPlayer.Inventory[i] != null)
            {
                newObj.GetComponent<Image>().sprite = GameState.CurrentPlayer.Inventory[i].Sprite;
            }
        }
        return GameState.CurrentPlayer.Inventory.Count;
    }
}
