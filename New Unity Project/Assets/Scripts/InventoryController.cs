using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{    
    public InventoryObject PlayerInventory;
    public GameObject inventoryPrefab;

    public int X_START;
    public int Y_START;
    public int NUMBER_OF_COLUMN;
    public int X_SPACE_BETWEEN_ITEMS;    
    public int Y_SPACE_BETWEEN_ITEMS;

    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

    public MouseItem mouseItem = new MouseItem();

    public Image DropHelper;
    Animator inventoryAnimator;

    public ItemObject TestItemObject;
    public int TestAmount;
    bool HelperStatus = false;

    void Start()
    {
        CreateSlots();
        inventoryAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateSlots();

        if (HelperStatus)
        {
            float T = Mathf.Sin(Time.time * 3f) * 0.5f + 0.7f;
            float shimmer = Mathf.Lerp(0.05f, 0.15f, T);
            DropHelper.color = new Color(DropHelper.color.r, DropHelper.color.g, DropHelper.color.b, shimmer);
        }
    }


    //Slots creating and Updating
    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> slot in itemsDisplayed)
        {
            if (slot.Value.ID > 0)
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = PlayerInventory.database.GetItem[slot.Value.item.id].image;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().enabled = true;
                slot.Key.GetComponentInChildren<Text>().text = slot.Value.amount.ToString();
            }
            else
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().enabled = false;
                slot.Key.GetComponentInChildren<Text>().text = " ";
            }
        }
    }

    public void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < PlayerInventory.Container.Slots.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            
            itemsDisplayed.Add(obj, PlayerInventory.Container.Slots[i]);
            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }


    //Test Button
    public void AddItemButton()
    {
        PlayerInventory.AddItem(TestItemObject, TestAmount);
    }

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
        {
            mouseItem.hoverItem = itemsDisplayed[obj];
        }
    }
    public void OnExit(GameObject obj)
    {
        mouseItem.hoverObj = null;
        mouseItem.hoverItem = null;
        
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50);
        mouseObject.transform.SetParent(transform.parent);
        if(itemsDisplayed[obj].ID > 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = PlayerInventory.database.GetItem[itemsDisplayed[obj].ID].image;
            img.raycastTarget = false;
        }
        mouseItem.obj = mouseObject;
        mouseItem.item = itemsDisplayed[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        if (mouseItem.hoverObj)
        {
            PlayerInventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[mouseItem.hoverObj]);
        }
        else if (true)
        {

        }
        else
        {
            //PlayerInventory.RemoveItem(itemsDisplayed[obj]);
        }
        DropHelper.color = new Color(DropHelper.color.r, DropHelper.color.g, DropHelper.color.b, 0f);
        HelperStatus = false;
        Destroy(mouseItem.obj);
        mouseItem.item = null;
    }
    public void OnDrag(GameObject obj)
    {        
        if (mouseItem.obj != null)
        {
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
            HelperStatus = true;
        }
    }

   
    public void OpenCloseSwitcher()
    {
        if (inventoryAnimator.GetBool("open") == false)
        {
            inventoryAnimator.SetBool("open", true);
        }
        else
        {
            inventoryAnimator.SetBool("open", false);
        }

    }

}

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public GameObject hoverObj;
    public InventorySlot hoverItem;

}

