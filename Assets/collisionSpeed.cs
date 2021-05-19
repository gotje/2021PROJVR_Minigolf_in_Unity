using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;



public class collisionSpeed : MonoBehaviour
{
    Vector3 previous;
    Vector3 velocity;
    float prevTimeColl; 
    float prevTimeFixedUpdate;
    private Rigidbody myRigidbody;
    Vector3 previousColl;
    private int restrictedLayer = 12;
    private int freedLayer = 0;
    int frames = 0;

    void Start()
    {
        prevTimeColl = 0;
        prevTimeFixedUpdate = 0;
        myRigidbody = GetComponent<Rigidbody>();
        previous = transform.position;
        previousColl = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        frames++;
        this.gameObject.layer = freedLayer;
        if (frames > 4)
        {
            if (collision.gameObject.tag == "golfBall")
            {
                frames = 0;
                float delta = (float)DateTime.Now.Millisecond - prevTimeColl;
                velocity = new Vector3(transform.position.x - previousColl.x, 0, transform.position.z - previousColl.z) / delta;
                Debug.Log(velocity);
                this.gameObject.layer = restrictedLayer;
                collision.rigidbody.velocity = velocity * 5;
                Debug.Log(collision.rigidbody.velocity);
            }
        }
        prevTimeColl = (float)DateTime.Now.Millisecond;
        previousColl = transform.position;
    }

    void FixedUpdate()
    {
        frames++;
        this.gameObject.layer = freedLayer;
        if (frames > 4)
        {
            Ray ray = new Ray(myRigidbody.position, previous);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "golfBall")
                {
                    frames = 0;
                    float delta = (float)DateTime.Now.Millisecond - prevTimeFixedUpdate;
                    velocity = new Vector3(transform.position.x - previous.x, 0, transform.position.z - previous.z) / delta * 5;
                    this.gameObject.layer = restrictedLayer;
                    velocity.x = 0;
                    GameObject.Find("GolfBall").GetComponent<Rigidbody>().velocity = velocity;
                }
            }
        }
        previous = transform.position;
        prevTimeFixedUpdate = (float)DateTime.Now.Millisecond;
        
    }
}


