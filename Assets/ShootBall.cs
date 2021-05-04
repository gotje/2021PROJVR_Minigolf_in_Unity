using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    GameObject baseball;

    void Main()
    {
        baseball = GameObject.Find("Baseball");
        baseball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5000);
    }

    
}
