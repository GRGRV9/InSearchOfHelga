using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Animator controller;
    public InventoryObject inventoryObject;
    public List<InventoryItem> items;
    private static readonly int Open1 = Animator.StringToHash("open");

    void Start()
    {
        for (int i = 0; i < inventoryObject.container.Count; i++)
        {
            items[i].SetImage(inventoryObject.container[i].image);
        }
    }

    void Update()
    {
        
    }

    public void Close()
    {
        controller.SetBool(Open1,false);
    }

    public void Open()
    {
        controller.SetBool(Open1,true);
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
            myScript.items= new List<InventoryItem>( myScript.gameObject.GetComponentsInChildren<InventoryItem>());
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
