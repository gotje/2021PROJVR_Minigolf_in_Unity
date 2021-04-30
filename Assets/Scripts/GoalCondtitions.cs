using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCondtitions : MonoBehaviour
{
    private static ArrayList teleportLocations = new ArrayList();
    public static int currentHole = 0;

    public void Main()
    {
        Debug.Log("Setting up teleportations");
        //teleportLocations.Add(new Vector3(0, 5, 0));
        //teleportLocations.Add(new Vector3(40, 5f, -15));
        GameObject[] startPoints = GameObject.FindGameObjectsWithTag("startPoint");
        foreach (GameObject startpoint in startPoints)
        {
            teleportLocations.Add(new Vector3(startpoint.transform.position.x, startpoint.transform.position.y + 0.5f, startpoint.transform.position.z));
        }
        ResetBallLocation.lastPosition = (Vector3)teleportLocations[0];
    }

    public static void GoalResults(Collider other)
    {
        GameObject vrRig = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Ball is in hole");
        Debug.Log(currentHole);
        Debug.Log(teleportLocations.Count);
        //Debug.Log((Vector3)teleportLocations[Int32.Parse(this.gameObject.name.Split('_')[1] + 1)]);
        //other.gameObject.transform.position = (Vector3)teleportLocations[Int32.Parse(this.gameObject.name.Split('_')[1] + 1)];
        //vrRig.transform.position = (Vector3)teleportLocations[Int32.Parse(this.gameObject.name.Split('_')[1] + 1)];
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        other.gameObject.transform.position = (Vector3)teleportLocations[currentHole];
        vrRig.transform.position = (Vector3)teleportLocations[currentHole];
        ResetBallLocation.lastPosition = (Vector3)teleportLocations[currentHole];
        ScoreBoardManipulator.FinishedHole();
    }
}
