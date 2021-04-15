using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collider : MonoBehaviour
{
    private ArrayList teleportLocations = new ArrayList();

    public void Main()
    {
        teleportLocations.Add(new Vector3(0, 5, 0));
        teleportLocations.Add(new Vector3(40, 5f, -15));
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject vrRig = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Ball is in hole");
        Debug.Log((Vector3)teleportLocations[Int32.Parse(this.gameObject.name.Split('_')[1] + 1)]);
        other.gameObject.transform.position = (Vector3)teleportLocations[Int32.Parse(this.gameObject.name.Split('_')[1] + 1)];
        vrRig.transform.position = (Vector3)teleportLocations[Int32.Parse(this.gameObject.name.Split('_')[1] + 1)];

    }
}
