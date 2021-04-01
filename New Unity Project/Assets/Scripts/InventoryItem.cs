using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour//,IPointerClickHandler
{
    public Image itemPic;
    public InventorySlot data;
    public InventoryController controller;
    [SerializeField] private Text amountText;

    private void Update()
    {
        itemPic.sprite = data.item.image;
        
    }

    //public void SetItem(InventorySlot obj)
    //{
    //    itemPic.sprite = obj.item.image;
    //    data = obj;
    //    amountText.text = obj.amount.ToString();
    //    itemPic.enabled = true;
    //}

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    controller.SelectItem(data);
    //}
}
