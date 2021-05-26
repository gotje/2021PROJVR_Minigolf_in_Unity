using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class HoleSound : MonoBehaviour
{
	public AudioClip BallDrop;
	AudioSource soundSource;
	RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
    	soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


