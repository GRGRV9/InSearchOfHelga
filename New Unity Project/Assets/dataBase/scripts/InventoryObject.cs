using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    public TestDb database;
    public Inventory Container;

    //FUNCTIONS
    public void AddItem(ItemObject newItem, int newAmount)
    {
        
        for (int i = 0; i < Container.Slots.Length; i++)
        {
            
            if (Container.Slots[i].ID == newItem.id)
            {

                if (Container.Slots[i].amount + newAmount <= 30)
                {
                    Container.Slots[i].AddAmount(newAmount);                    
                    return;
                }
                else if (Container.Slots[i].amount == 30)
                {
                    continue;
                }
                else 
                {
                    int difference = 30 - Container.Slots[i].amount;
                    Container.Slots[i].AddAmount(difference);
                    SetEmptySlot(newItem, newAmount - difference);
                    return;
                }                
            }
        }
        SetEmptySlot(newItem, newAmount);        
    }

    public InventorySlot SetEmptySlot(ItemObject item, int amount)
    {
        for (int i = 0; i < Container.Slots.Length; i++)
        {
            if(Container.Slots[i].ID == 0)
            {
                Container.Slots[i].UpdateSlot(item.id, item, amount);
                return Container.Slots[i];
            }
        }
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount);
        item1.UpdateSlot(temp.ID, temp.item, temp.amount);
    }

    public void RemoveItem(InventorySlot slot)
    {
        //for (int i = 0; i < Container.Slots.Length; i++)
        //{
            //if (Container.Slots[i].item == item)
            //{
                 slot.UpdateSlot(0, null, 0);
            //}
        //}
    }

    public void ClearInventory()
    {
        Container = new Inventory();
    }

    //SERIALIZING
    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Slots.Length; i++)
        {
            Container.Slots[i].item = database.GetItem[Container.Slots[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}

//INVENTORY & SLOT CLASSES
[System.Serializable]
public class Inventory
{
    public InventorySlot[] Slots = new InventorySlot[16];
}


[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;
    public int maxCapacity = 30;

    public InventorySlot(int id, ItemObject newItem, int newAmount)
    {
        ID = id;
        item = newItem;
        amount = newAmount;
    }
    public void UpdateSlot(int id, ItemObject newItem, int newAmount)
    {
        ID = id;
        item = newItem;
        amount = newAmount;
    }

    public void AddAmount(int newAmount)
    {
        amount += newAmount;
    }
}