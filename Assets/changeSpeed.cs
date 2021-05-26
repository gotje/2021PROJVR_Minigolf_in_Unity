using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class changeSpeed : MonoBehaviour
{
	public bool sendTriggerMessage = false;

	public LayerMask layerMask = 0;
	public float skinWidth = 0.1f;

	private float minimumExtent;
	private float partialExtent;
	private float sqrMinimumExtent;
	private Vector3 previousPosition;
	private Vector3 previousVelocity;
	private Rigidbody myRigidbody;
	private Collider myCollider;
	private readonly System.Random random = new System.Random();

	private 

	//initialize values 
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody>();
		myCollider = GetComponent<Collider>();
		previousPosition = myRigidbody.position;
		previousVelocity = myRigidbody.velocity;
		minimumExtent = Mathf.Min(Mathf.Min(myCollider.bounds.extents.x, myCollider.bounds.extents.y), myCollider.bounds.extents.z);
		partialExtent = minimumExtent * (1.0f - skinWidth);
		sqrMinimumExtent = minimumExtent * minimumExtent;
	}

	void Update()
	{
		int randomNum = random.Next(100,300);
		float randomFloat = randomNum / 100;
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
				if (!hitInfo.collider)
				{
					return;
				}
				if (hitInfo.collider.isTrigger)
				{
					hitInfo.collider.SendMessage("OnTriggerEnter", myCollider);
				}
				if (!hitInfo.collider.isTrigger)
				{
					myRigidbody.position = hitInfo.point - (movementThisStep / movementMagnitude) * partialExtent;
					myRigidbody.velocity = previousVelocity * (-2) * randomFloat;
				}
			}
		}
		previousPosition = myRigidbody.position;
		previousVelocity = myRigidbody.velocity;
	}

	void OnCollisionEnter()
    {
		int randomNum = random.Next(100, 300);
		float randomFloat = randomNum / 100;
		myRigidbody.velocity = previousVelocity * (-2) * randomFloat;
	}
}
