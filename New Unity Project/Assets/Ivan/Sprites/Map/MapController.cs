using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject Map;
    public GameObject OpenMapButton;
    public GameObject CloseMapButton;

    public void OpenMap()
    {
        Map.SetActive(true);
        OpenMapButton.SetActive(false);
    }

    public void CloseMap()
    {
        Map.SetActive(false);
        OpenMapButton.SetActive(true);
    }

}
