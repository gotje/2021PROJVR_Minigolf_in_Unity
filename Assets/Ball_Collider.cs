using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GoalCondtitions.currentHole = GoalCondtitions.currentHole + 1;
        GoalCondtitions.GoalResults(other);
        AudioSource BallDrop = this.GetComponent<AudioSource>();
        BallDrop.Play();
    }

}
