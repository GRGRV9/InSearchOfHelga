using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject:ScriptableObject
{
    public List<ItemObject> container = new List<ItemObject>();
}