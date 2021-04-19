using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLastPosition : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter - Setting LastLocation");
        Debug.Log(other.gameObject.name);
        ResetBallLocation.lastPosition = other.transform.position;
    }
}
