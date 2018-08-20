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

    [SerializeField]
    private Text weaponStats;

    private int amountOfItems;
    private string _stats;
    public bool _mouseOver;

    public void ShowWeaponStats(GameObject ItemSlot)
    {
        //GameObject selectedItem = UnityEngine.EventSystems.EventSystem.current.gameObject;
        InventoryItem item = GameState.CurrentPlayer.FindItemByImage(ItemSlot.GetComponent<Image>().sprite);
        if (item != null)
        {
            //_stats = "Name: " + item.ItemName + "\n" +
            //                    "Strength: " + item.Strength + "\n" +
            //                    "Cost: " + item.Cost + "\n" +
            //                    "Defence: " + item.Defense;
            _mouseOver = true;
            //weaponStats = Resources.Load("WeaponStats") as GameObject;
            weaponStats.text = "Name: " + item.ItemName + "\n" +
                                "Strength: " + item.Strength + "\n" +
                                "Cost: " + item.Cost + "\n" +
                                "Defence: " + item.Defense;
        }
    }

    private void OnGUI()
    {
        if (_mouseOver)
        {
            GUI.Box(new Rect(Input.mousePosition.GetScreenPositionFor2D().x, Input.mousePosition.GetScreenPositionFor2D().y,100,100), _stats);
            //GUI.Label(new Rect(Input.mousePosition.x, Input.mousePosition.y, 100, 100), _stats);
        }
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
        weaponStats.text = "";
    }

    private void Start()
    {
        amountOfItems = Populate();
        _mouseOver = false;
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
