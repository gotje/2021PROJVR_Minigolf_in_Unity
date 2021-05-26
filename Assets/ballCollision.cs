using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ballCollision : MonoBehaviour
{
    public bool sendTriggerMessage = false;

    public LayerMask layerMask = 0;
    public float skinWidth = 0.1f;

    private float minimumExtent;
    private float partialExtent;
    private float sqrMinimumExtent;
    private Vector3 previousPosition;
    private Rigidbody myRigidbody;
    private Collider myCollider;
    private changeLastPosition change;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        previousPosition = myRigidbody.position;
        minimumExtent = Mathf.Min(Mathf.Min(myCollider.bounds.extents.x, myCollider.bounds.extents.y), myCollider.bounds.extents.z);
        partialExtent = minimumExtent * (1.0f - skinWidth);
        sqrMinimumExtent = minimumExtent * minimumExtent;
        change = new changeLastPosition();

    }
    void OnCollision(Collision collision)
    { 
        if (collision.gameObject.tag == "GameController")
        {
            myRigidbody.velocity = myRigidbody.velocity * 4;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(myRigidbody.position, previousPosition);
        //RaycastHit hitInfo;
        //if (Physics.Raycast(ray, out hitInfo))
        //{
        //    if (hitInfo.collider.tag == "GameController")
        //    {
        //        myRigidbody.velocity = GameObject.Find("Right hand").GetComponent<Rigidbody>().velocity * 50;
        //    }
        //}
        //previousPosition = transform.position;
    }
}
