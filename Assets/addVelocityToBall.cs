using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addVelocityToBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        other.rigidbody.velocity = GetComponent<Rigidbody>().velocity;
    }
}
