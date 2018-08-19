using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryItemAssetCreator : MonoBehaviour {

	[MenuItem("Assets/Create/Inventory Item")]
    public static void CreateAsset()
    {
        CustomAssetUtility.CreateAsset<InventoryItem>();
    }
}
