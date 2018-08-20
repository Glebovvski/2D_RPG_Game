using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManger : MonoBehaviour {

    [SerializeField]
    private Text playerStats;

    [SerializeField]
    private Text weaponStats;

    public InventoryItem debugItem;


    public void ShowWeaponStats(GameObject ItemSlot)
    {
        //GameObject selectedItem = UnityEngine.EventSystems.EventSystem.current.gameObject;
        Image itemImage = ItemSlot.GetComponent<Image>();
        InventoryItem item = GameState.CurrentPlayer.FindItemByImage(itemImage.sprite);
        if (item != null)
        {
            weaponStats.text = "Name: " + item.ItemName + "\n" +
                                "Strength: " + item.Strength + "\n" +
                                "Cost: " + item.Cost + "\n" +
                                "Defence: " + item.Defense;
        }
    }

    public void HideWeaponStats()
    {
        weaponStats.text = "";
    }

    private void Awake()
    {
        //playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
        playerStats.text = "Level: " + GameState.CurrentPlayer.Level + "\n" +
            "Health: " + GameState.CurrentPlayer.Health + "\n" +
            "Strength: " + GameState.CurrentPlayer.Strength + "\n" +
            "Magic: " + GameState.CurrentPlayer.Magic + "\n" +
            "Defence: " + GameState.CurrentPlayer.Defense + "\n" +
            "Damage: " + GameState.CurrentPlayer.Damage + "\n" +
            "Armor: " + GameState.CurrentPlayer.Armor;
       // weaponStats = GameObject.FindGameObjectWithTag("WeaponStats");
    }

    private void OnGUI()
    {   //
        //if (_mouseOver)
        //{
        //    GUI.Box(new Rect(Input.mousePosition.GetScreenPositionFor2D().x, Input.mousePosition.GetScreenPositionFor2D().y,100,100), _stats);
        //    //GUI.Label(new Rect(Input.mousePosition.x, Input.mousePosition.y, 100, 100), _stats);
        //}
    }
}
