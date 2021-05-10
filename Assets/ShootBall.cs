using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    static GameObject baseball;
    static GameObject ballMachine;

    void Main()
    {
        baseball = GameObject.Find("Baseball");
        ballMachine = GameObject.Find("BallMachine");
        ResetPosition();
        ThrowArch();
    }

    public static void ThrowBall()
    {
        ResetPosition();
        ThrowArch();
    }

    static void ResetPosition()
    {
        baseball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        baseball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        baseball.transform.position = ballMachine.transform.position;
    }

    static void ThrowArch()
    {
        baseball.GetComponent<Rigidbody>().velocity = new Vector3(0, 7.5f, -8.5f);
    }

    
}
