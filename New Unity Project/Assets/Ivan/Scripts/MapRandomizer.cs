using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRandomizer : MonoBehaviour
{
    public GameObject[] IslandsArray;
    
    
    void Start()
    {

        for (int i = 0; i < IslandsArray.Length ; i++)
        {
            Vector3 position = new Vector3(Random.Range(-12.0f, 12.0f), Random.Range(-6.0f, 6f), 15);

            if (i>0 && Vector3.Distance(position, IslandsArray[i - 1].transform.localPosition) < 1)
            {
                position.x += 2f;
                position.y += 2f;
            }

            IslandsArray[i].transform.localPosition = position;          

        }
    }

    
}
