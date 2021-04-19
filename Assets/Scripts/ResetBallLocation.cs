using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallLocation : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter - Resetting ballLocation");
        Debug.Log(other.gameObject.name);
        Vector3 startPosition = new Vector3(0, 0.5f, 0);
        other.gameObject.transform.position = startPosition;
        other.rigidbody.velocity = Vector3.zero;
        other.rigidbody.angularVelocity = Vector3.zero;
    }
}
