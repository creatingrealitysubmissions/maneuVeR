using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour {
    public AudioClip heli;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.PlayOneShot(heli, 0.5f);
        transform.Rotate(Vector3.up * Time.deltaTime * 1000 );
	}
}
