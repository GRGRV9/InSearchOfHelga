using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();

    public void AddItem(ItemObject newItem, int newAmount)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item.type == newItem.type)
            {
                container[i].AddAmount(newAmount);
                return;
            }
        }
        container.Add(new InventorySlot(newItem,newAmount));
        
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject newItem, int newAmount)
    {
        item = newItem;
        amount = newAmount;
    }

    public void AddAmount(int newAmount)
    {
        amount += newAmount;
    }
}