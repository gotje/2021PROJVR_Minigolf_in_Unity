using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDistance : MonoBehaviour
{
    private void FixedUpdate()
    {
        UpdateScreen();
    }

    private void UpdateScreen()
    {
        Vector3 baseballLocation = GameObject.Find("Baseball").transform.position;
        Vector3 playerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distance = Mathf.Sqrt(Mathf.Pow((baseballLocation.x - playerLocation.x), 2) + Mathf.Pow((baseballLocation.z - playerLocation.z),2));
        this.GetComponentInChildren<Text>().text = "" + (float)Mathf.Round(distance*100)/100;
    }
}
