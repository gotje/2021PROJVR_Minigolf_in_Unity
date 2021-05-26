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
            if (collision.gameObject.tag == "golfBall")
            {
                collision.rigidbody.velocity = collision.rigidbody.velocity * 130;
            }
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(myRigidbody.position, previous);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.tag == "golfBall")
            {
                GameObject.Find("GolfBall").GetComponent<Rigidbody>().velocity = GameObject.Find("GolfBall").GetComponent<Rigidbody>().velocity * 130;
            }
        }
    }
    void collisionSound(){
    	//play sound ball collision putter

    	
    }
}


