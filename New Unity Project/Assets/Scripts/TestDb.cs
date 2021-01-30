using UnityEngine;
    [CreateAssetMenu(fileName = "date base",menuName = "Inventory System/Items/DateBase")]
    public class TestDb:ScriptableObject,ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
           
        }

        public void OnAfterDeserialize()
        {
            
        }
    }