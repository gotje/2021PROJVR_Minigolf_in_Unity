using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLastPosition : MonoBehaviour
{
    private Vector3 prevLoc;
    public Vector3 prevSpeed = new Vector3();
    float speed = 0;

    void Start()
    {
        prevLoc = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter - Setting LastLocation");
        Debug.Log(other.gameObject.name);
        ResetBallLocation.lastPosition = other.transform.position;
        ScoreBoardManipulator.increaseScore();
        other.rigidbody.velocity = prevSpeed * 2;
    }

    void Update()
    {
        prevSpeed = transform.position - prevLoc;
        prevLoc = transform.position;
    }

    public Vector3 GetSpeed()
    {
        return prevSpeed;
    }
}
