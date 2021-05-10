using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class collisionSpeed : MonoBehaviour
{
    Vector3 previous;
    float velocity;

    void Start()
    {
        previous = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pir (2)")
        {
            velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
            collision.rigidbody.velocity = previous * 3;
        }
    }
    void Update()
    {
        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;
    }
}


