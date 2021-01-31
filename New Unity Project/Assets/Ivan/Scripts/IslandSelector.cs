using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSelector : MonoBehaviour
{
    public GameObject NavigationMarker;
    public Vector3 PickedIslandPosition;
    public GameObject Ship;    
    float DistanceToMarker;
    public AudioSource ShipStartSound;

    void Update()
    {
        MouseInput(); 
    }

    void MouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

            if(hit.collider.gameObject.tag == "Island")
            {                       
                NavigationMarker.transform.position = hit.collider.gameObject.transform.position;
                ShipStartSound.Play();
                CalculateDistanceToMarker();
            }
            else
            {                
                //NavigationMarker.transform.position = Ship.transform.position;
            }
        }
    }

    void CalculateDistanceToMarker()
    {
        DistanceToMarker = Vector2.Distance(Ship.transform.position, NavigationMarker.transform.position);        
    }
}
