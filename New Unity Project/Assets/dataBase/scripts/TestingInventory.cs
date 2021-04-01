using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInventory : MonoBehaviour
{
    public Inventory Container;
    public ItemObject TestItemObject;
    public int TestAmount;

    private void Start()
    {
        
    }

    public void AddItemButton()
    {
        AddItem(TestItemObject, TestAmount);
    }

    public void AddItem(ItemObject newItem, int newAmount)
    {
        for (int i = 0; i < Container.Slots.Length; i++)
        {            
            if (Container.Slots[i].ID == newItem.id)
            {
                Container.Slots[i].AddAmount(newAmount);                
                Debug.Log("AddAmount: " + newAmount);
                return;
            }
            
        }
        
        SetEmptySlot(newItem, newAmount);

    }

    public InventorySlot SetEmptySlot(ItemObject newItem, int newAmount)
    {        
        for (int i = 0; i < Container.Slots.Length; i++)
        {            
            if (Container.Slots[i].ID == 0)
            {                
                Container.Slots[i].UpdateSlot(newItem.id, newItem, newAmount);
                return Container.Slots[i];
            }
        }
        return null;
    }
}
