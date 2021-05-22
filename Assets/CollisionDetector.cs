using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        UpdateDistance.baseballhit = true;
    }
}
