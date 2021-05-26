using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;


public class collisionSpeed : MonoBehaviour
{
    Vector3 previous;
    Vector3 velocity;
    float prevTimeFixedUpdat;
    float prevTimeFixedUpdate;
    private Rigidbody myRigidbody;
    Vector3 previousc;
    private int restrictedLayer = 12;
    private int freedLayer = 0;
    int frames = 0;
    private int counter;

    void Start()
    {
        prevTimeFixedUpdat = 0;
        prevTimeFixedUpdate = 0;
        myRigidbody = GetComponent<Rigidbody>();
        previous = transform.position;
        previousc = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        //frames++;
        //this.gameObject.layer = freedLayer;
        //if (frames > 4)
        //{
        //    if (collision.gameObject.tag == "golfBall")
        //    {
        //        frames = 0;
        //        float delta = (float)DateTime.Now.Millisecond - prevTimeFixedUpdate;
        //        velocity = new Vector3(transform.position.x - previous.x, 0, transform.position.z - previous.z);
        //        Debug.Log(velocity + "velocity putter");
        //        this.gameObject.layer = restrictedLayer;
        //        collision.rigidbody.velocity = velocity * 5;
        //        Debug.Log(collision.rigidbody.velocity + "new velocity ball");
        //        collisionSound();
        //    }
        //}
        //prevTimeFixedUpdate = (float)DateTime.Now.Millisecond;
        //previous = transform.position;
        FixedUpdate();
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
                    velocity = new Vector3(transform.position.x - previous.x, 0, transform.position.z - previous.z) * 200;
                    this.gameObject.layer = restrictedLayer;
                    GameObject.Find("GolfBall").GetComponent<Rigidbody>().velocity = velocity;
                    collisionSound();
                    Debug.Log("RAYCASTING" + GameObject.Find("GolfBall").GetComponent<Rigidbody>().velocity);
                    Debug.Log("DELTA: " + delta);
                    ScoreBoardManipulator.increaseScore();
                }
            }
        }
        previous = transform.position;
        prevTimeFixedUpdate = (float)DateTime.Now.Millisecond;
        counter = 0;
    }

    void collisionSound()
    {
        //play sound ball collision putter
    }
}
