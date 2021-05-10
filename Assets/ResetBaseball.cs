using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBaseball : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        ShootBall.ThrowBall();
    }
}
