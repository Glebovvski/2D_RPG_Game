﻿using UnityEngine;

public class PlayerInventoryDisplay : MonoBehaviour
{
    #region MyInventory

    [SerializeField]
    private Canvas _inventory;

    private bool displayed;

    private void Awake()
    {
        displayed = false;
    }

    private void Start()
    {
        _inventory.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            displayed = !displayed;
            _inventory.gameObject.SetActive(displayed);
        }
    }

    #endregion

    #region OldInventory


    /*bool displayInventory = false;

    Rect inventoryWindowRect;
    private Vector2 inventoryWindowSize = new Vector2(150, 150);

    Vector2 inventoryItemIconSize = new Vector2(130, 32);

    float offsetX = 6;
    float offsetY = 6;

    void Awake()
    {
        inventoryWindowRect = new Rect(
            Screen.width - inventoryWindowSize.x,
            Screen.height - 40 - inventoryWindowSize.y,
            inventoryWindowSize.x,
            inventoryWindowSize.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            displayInventory = !displayInventory;
        }
    }

    void OnGUI()
    {
        if (displayInventory)
        {
            inventoryWindowRect = GUI.Window(
                0,
                inventoryWindowRect,
                DisplayInventoryWindow,
                "Inventory");

            inventoryWindowSize = new Vector2(
                inventoryWindowRect.width,
                inventoryWindowRect.height);
        }
    }

    void DisplayInventoryWindow(int windowID)
    {
        var currentX = 0 + offsetX;
        var currentY = 18 + offsetY;
        foreach (var item in GameState.CurrentPlayer.Inventory)
        {
            Rect texcoords = item.Sprite.textureRect;

            texcoords.x /= item.Sprite.texture.width;
            texcoords.y /= item.Sprite.texture.height;
            texcoords.width /= item.Sprite.texture.width;
            texcoords.height /= item.Sprite.texture.height;

            GUI.DrawTextureWithTexCoords(new Rect(
                currentX,
                currentY,
                item.Sprite.textureRect.width,
                item.Sprite.textureRect.height),
                item.Sprite.texture,
                texcoords);


            currentX += inventoryItemIconSize.x;
            if (currentX + inventoryItemIconSize.x +
                offsetX > inventoryWindowSize.x)
            {
                currentX = offsetX;
                currentY += inventoryItemIconSize.y;
                if (currentY + inventoryItemIconSize.y +
                    offsetY > inventoryWindowSize.y)
                {
                    return;
                }
            }
        }
    }
    */
    #endregion
}

