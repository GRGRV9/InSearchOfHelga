using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Animator controller;
    [SerializeField] private Text text;
    [SerializeField] private Image selectedImage;
    public InventoryObject inventoryObject;
    public List<InventoryItem> items;
    private static readonly int Open1 = Animator.StringToHash("open");

    void Start()
    {
        for (int i = 0; i < inventoryObject.container.Count; i++)
        {
            items[i].SetItem(inventoryObject.container[i]);
        }
    }

    void Update()
    {
    }

    public void Close()
    {
        controller.SetBool(Open1, false);
    }

    public void Open()
    {
        controller.SetBool(Open1, true);
    }

    public void SelectItem(InventorySlot obj)
    {
        if (obj==null)
        {
            selectedImage.enabled = false;
            text.text = "";
            return;
        }
        text.text = obj.item.description;
        selectedImage.sprite = obj.item.image;
        selectedImage.enabled = true;
    }
}

[CustomEditor(typeof(InventoryController))]
public class InventoryControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        InventoryController myScript = (InventoryController) target;
        if (GUILayout.Button("get items"))
        {
            myScript.items = new List<InventoryItem>(myScript.gameObject.GetComponentsInChildren<InventoryItem>());
            foreach (var myScriptItem in myScript.items)
            {
                myScriptItem.controller = myScript;
            }
        }

        if (GUILayout.Button("open"))
        {
            myScript.Open();
        }

        if (GUILayout.Button("close"))
        {
            myScript.Close();
        }
    }
}