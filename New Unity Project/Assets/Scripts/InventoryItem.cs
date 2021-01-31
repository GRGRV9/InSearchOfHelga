using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour,IPointerClickHandler
{
    public Image item;
    public InventorySlot data;
    public InventoryController controller;
    [SerializeField] private Text amountText;


    public void SetItem(InventorySlot obj)
    {
        item.sprite = obj.item.image;
        data = obj;
        amountText.text = obj.amount.ToString();
        item.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.SelectItem(data);
    }
}
