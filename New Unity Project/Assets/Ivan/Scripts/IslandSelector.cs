using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandSelector : MonoBehaviour
{
    public GameObject NavigationMarker;
    public Vector3 PickedIslandPosition;
    public GameObject MiniShip;    
    public float DistanceToMarker;
    bool selectorIsActive = false;

    public AudioSource ShipStartSound;
    public GameObject LevelShip;
    Animator ShipAnimator;

    public GameObject Map;
    public GameObject OpenMapButton;
    public GameObject PlayerInventory;

    public Slider MaterialSlider;
    public Slider FoodSlider;
    public Slider WaterSlider;

    float PlayerMaterialCount;
    float PlayerFoodCount;
    float PlayerWaterCount;

    float FoodCost;
    float MaterialCost;
    float WaterCost;

    double DistanceToShip;

    public GameObject NavigationMarkerObject;

    public GameObject DeathScreen;

    void Start()
    {
        ShipAnimator = LevelShip.GetComponent<Animator>();
        PlayerMaterialCount = 20;
        PlayerFoodCount = 30;
        PlayerWaterCount = 40;
    }

    void Update()
    {
        MouseInput();
        MaterialSlider.value = PlayerMaterialCount;
        FoodSlider.value = PlayerFoodCount;
        WaterSlider.value = PlayerWaterCount;

        if(PlayerMaterialCount<1 || PlayerWaterCount<1 || PlayerFoodCount < 1)
        {
            DeathScreen.SetActive(true);
        }

    }

    public void SetIslandSelectorOn()
    {
        selectorIsActive = true;
    }

    public void SetIslandSelectorOff()
    {
        selectorIsActive = false;
    }

    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

            if (selectorIsActive)
            {
                if (hit.collider.gameObject.tag == "Island")
                {
                    NavigationMarker.transform.position = hit.collider.gameObject.transform.position;
                    ShipStartSound.Play();
                    CalculateCostOfTravel();
                    NavigationMarkerObject.SetActive(false);
                    StartCoroutine(ShipAnimatorSwitcher());

                }
            }                    
        }
    }

    private IEnumerator ShipAnimatorSwitcher()
    {        
        ShipAnimator.SetBool("IsStarted", true);
        SetIslandSelectorOff();
        PlayerInventory.SetActive(false);
        yield return new WaitForSeconds(2f);
        Map.SetActive(false);
        NavigationMarkerObject.SetActive(true);
        OpenMapButton.SetActive(true);
        ShipAnimator.SetBool("IsStarted", false);
        PlayerInventory.SetActive(true);

    }

    void CalculateCostOfTravel()
    {
        DistanceToShip = Vector2.Distance(transform.position, MiniShip.transform.position) - 1;
        FoodCost = Convert.ToInt32(Math.Round(DistanceToShip * 1.5));
        WaterCost = Convert.ToInt32(Math.Round(DistanceToShip * 2));
        MaterialCost = Convert.ToInt32(Math.Round(DistanceToShip * 1.2));

        PlayerMaterialCount -= MaterialCost;
        PlayerFoodCount -= FoodCost;
        PlayerWaterCount -= WaterCost;
    }

    
}
