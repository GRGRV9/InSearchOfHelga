using System;
using UnityEngine;
using UnityEngine.UI;

public class SailCostViewer : MonoBehaviour
{
    public GameObject Ship;
    public Text FoodCost;
    public Text WaterCost;
    public Text MaterialCost;
    double DistanceToShip;
    double Cost;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToShip = Math.Round(Vector2.Distance(transform.position, Ship.transform.position));
        Cost = DistanceToShip * 11;
        FoodCost.text = DistanceToShip.ToString();
        WaterCost.text = DistanceToShip.ToString();
        MaterialCost.text = DistanceToShip.ToString();
    }
}
