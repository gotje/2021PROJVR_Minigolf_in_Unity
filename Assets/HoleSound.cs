﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter(Collision collision){
    	if (hitInfo.collider.tag == "BallSound"){
    		//play sound ball in hole

    	}
    }
}
