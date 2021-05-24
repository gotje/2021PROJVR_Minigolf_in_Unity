using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HoleSound : MonoBehaviour
{
	public AudioClip BallDrop;
	AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
    	soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter(Collision collision){
    	if (hitInfo.collider.tag == "BallSound"){
    		audioSource.PlayOneShot(BallDrop, 0,7F);

    	}
    	
    }
}
