using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public struct inventoryItem
    {
        public string itemID;
    }

    public List<inventoryItem> Inventory = new List<inventoryItem>();
    //add dictionary for inventory items

    public void GiveItem(inventoryItem item, InventoryScript recipient)
    {

    }
}
