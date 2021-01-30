using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public Transform ShipTransform;
    
    void LateUpdate()
    {
        UpdateCamPosition();
    }

    void UpdateCamPosition()
    {
        Vector3 newPos = ShipTransform.position;
        newPos.z = -10;
        transform.position = newPos;
    }
}
