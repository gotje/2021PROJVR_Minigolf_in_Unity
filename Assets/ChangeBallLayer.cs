using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallLayer : MonoBehaviour
{
    private int restrictedLayer = 9; //BallOutHole
    private int freedLayer = 11; //BallInHole

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision: " + other.gameObject.name + " - " + other.gameObject.layer); 
        if (other.gameObject.tag == "golfBall")
        {
            other.gameObject.layer = freedLayer;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision: " + other.gameObject.name + " - " + other.gameObject.layer);
        if (other.gameObject.tag == "golfBall")
        {
            other.gameObject.layer = restrictedLayer;
        }
    }
}
