using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject Map;
    public GameObject OpenMapButton;
    public GameObject CloseMapButton;
    public GameObject InventoryButton;
    public GameObject islandSelector;
    public GameObject PlayerInventory;
    

    public void OpenMap()
    {        
        Map.SetActive(true);
        OpenMapButton.SetActive(false);
        InventoryButton.SetActive(false);

        PlayerInventory.GetComponent<Animator>().SetBool("open", false);
        
        islandSelector.GetComponent<IslandSelector>().SetIslandSelectorOn();
}

    public void CloseMap()
    {
        Map.SetActive(false);
        OpenMapButton.SetActive(true);
        InventoryButton.SetActive(true);
        islandSelector.GetComponent<IslandSelector>().SetIslandSelectorOff();

    }

}
