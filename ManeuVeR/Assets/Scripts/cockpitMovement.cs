using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockpitMovement : MonoBehaviour {

	public bool grabed = false;
	public GameObject shifter;
	//public GameObject knob;
	private Rigidbody rbxrotation;
	private Rigidbody rbxposition;
	// Use this for initialization
	void Start () {
	//	rbxrotation = shifter.GetComponent<Rigidbody>();
		rbxposition = this.GetComponent<Rigidbody>();


	}

	// Update is called once per frame
	void Update () 
	{
		if (grabed) 
		{
			rbxposition.isKinematic = false;
			rbxposition.useGravity = true;
		}

		if(!grabed)
		 {
			rbxposition.isKinematic = true;
			rbxposition.useGravity = false;
		 }

		if(rbxposition.transform.position.x >= 0.1 || rbxposition.transform.position.x <= -0.1)
		 {	
		 	grabed = false;

		 }
	
	}
}
