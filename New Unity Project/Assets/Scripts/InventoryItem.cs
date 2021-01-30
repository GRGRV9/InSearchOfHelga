using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetImage(Sprite sp)
    {
        item.sprite = sp;
        item.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
