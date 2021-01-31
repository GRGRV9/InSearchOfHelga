using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour,IPointerClickHandler
{
    public Image item;
    public ItemObject data;
    // Start is called before the first frame update
    public InventoryController controller;
    void Start()
    {
        
    }

    public void SetItem(ItemObject obj)
    {
        item.sprite = obj.image;
        data = obj;
        item.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.SelectItem(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
