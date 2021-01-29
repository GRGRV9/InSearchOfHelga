using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{    
    public Animator MapAnimator;
    public GameObject MapButton;

    void Start()
    {
        MapAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMap()
    {
        MapAnimator.SetBool("MapOpening", true);
        MapButton.SetActive(false);
    }

    public void CloseMap()
    {
        MapAnimator.SetBool("MapOpening", false);
        MapButton.SetActive(true);
    }

}
