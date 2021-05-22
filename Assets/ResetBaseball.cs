using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBaseball : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        UpdateDistance.CheckMaxDistance(float.Parse(GameObject.Find("Distance").GetComponent<Text>().text));
        ShootBall.ThrowBall();
        UpdateDistance.baseballhit = false;
    }
}
