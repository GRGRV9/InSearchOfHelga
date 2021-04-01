using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Datebase",menuName = "Inventory System/DateBase")]
public class TestDb:ScriptableObject,ISerializationCallbackReceiver
{
    
    public ItemObject[] Items;
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemObject, int>();
        GetItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
    }
}