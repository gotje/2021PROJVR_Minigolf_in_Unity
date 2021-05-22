using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDistance : MonoBehaviour
{
    public static bool baseballhit = false;

    private void FixedUpdate()
    {
        UpdateScreen();
    }

    private static void UpdateScreen()
    {
        if (baseballhit)
        {
            Vector3 baseballLocation = GameObject.Find("Baseball").transform.position;
            Vector3 playerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
            float distance = Mathf.Sqrt(Mathf.Pow((baseballLocation.x - playerLocation.x), 2) + Mathf.Pow((baseballLocation.z - playerLocation.z), 2));
            GameObject.Find("Distance").GetComponentInChildren<Text>().text = "" + (float)Mathf.Round(distance * 100) / 100;
        }
    }

    public static void CheckMaxDistance(float currentMaxDistance)
    {
        GameObject maxScore = GameObject.Find("Top Score");
        float previousMaxDistance = float.Parse(maxScore.GetComponent<Text>().text);
        if(previousMaxDistance < currentMaxDistance)
        {
            maxScore.GetComponent<Text>().text = "" + currentMaxDistance;
        }
    }
}
