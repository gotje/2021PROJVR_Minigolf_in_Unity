using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colliderScript : MonoBehaviour
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

	//initialize values 
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

	void Update()
	{
		//have we moved more than our minimum extent? 
		Vector3 movementThisStep = myRigidbody.position - previousPosition;
		float movementSqrMagnitude = movementThisStep.sqrMagnitude;
		if (movementSqrMagnitude > sqrMinimumExtent)
		{
			float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
			RaycastHit hitInfo;
			//check for obstructions we might have missed 
			if (Physics.Raycast(previousPosition, movementThisStep, out hitInfo, movementMagnitude, layerMask.value))
			{
				if (!hitInfo.collider) {
					return;
				}
				if (hitInfo.collider.isTrigger) {
					hitInfo.collider.SendMessage("OnTriggerEnter", myCollider);
					if (hitInfo.collider.tag == "golfBall")
					{
						hitInfo.collider.GetComponent<Rigidbody>().velocity = myRigidbody.velocity * 3000;
					}
					Debug.Log("raycasthit");
				}
				if (!hitInfo.collider.isTrigger) {
					//myRigidbody.position = hitInfo.point - (movementThisStep / movementMagnitude) * partialExtent;
					if(hitInfo.collider.tag == "golfBall")
                    {
						hitInfo.collider.GetComponent<Rigidbody>().velocity = myRigidbody.velocity * 3000;
					}
					Debug.Log("raycasthit");
				}
			}
		}
		previousPosition = myRigidbody.position;
	}

	/*void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "pir (2)")
        {
			myRigidbody.velocity = GameObject.Find("PutterHead").GetComponent<Rigidbody>().velocity * 4;
			Debug.Log("collision with putter, speed: " + myRigidbody.velocity);
		}
		
    }*/
}
