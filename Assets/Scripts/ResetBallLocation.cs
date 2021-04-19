using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallLocation : MonoBehaviour
{
    public static Vector3 lastPosition = new Vector3(0, 0.5f, 0);

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter - Resetting ballLocation");
        Debug.Log(other.gameObject.name);
        other.gameObject.transform.position = lastPosition;
        other.rigidbody.velocity = Vector3.zero;
        other.rigidbody.angularVelocity = Vector3.zero;
    }
}
