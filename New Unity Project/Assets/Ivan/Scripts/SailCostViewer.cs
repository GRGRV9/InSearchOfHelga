using System;
using UnityEngine;
using UnityEngine.UI;

public class SailCostViewer : MonoBehaviour
{
    public GameObject Ship;
    public GameObject Canvas;
    public Text FoodCostText;
    public Text WaterCostText;
    public Text MaterialCostText;
    double DistanceToShip;
    double FoodCost;
    double WaterCost;
    double MaterialCost;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToShip = Vector2.Distance(transform.position, Ship.transform.position) - 1;

        FoodCost = Math.Round(DistanceToShip * 1.5);
        WaterCost = Math.Round(DistanceToShip * 2);
        MaterialCost = Math.Round(DistanceToShip * 1.2);

        FoodCostText.text = FoodCost.ToString();
        WaterCostText.text = WaterCost.ToString();
        MaterialCostText.text = MaterialCost.ToString();

        if (FoodCost < 2 || WaterCost < 2 || MaterialCost < 2)
        {
            Canvas.SetActive(false);
        }
        else
        {
            Canvas.SetActive(true);
        }
    }
}
