using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockpitMovement : MonoBehaviour {

	public bool grabed = false;
	public GameObject shifter;
	//public GameObject knob;
	private Rigidbody rbxrotation;
	private Rigidbody rbxposition;

	private Vector3 originalPosition;

	private Vector3 tempPosition; 

	// Use this for initialization
	void Start () {
	//	rbxrotation = shifter.GetComponent<Rigidbody>();
		rbxposition = this.GetComponent<Rigidbody>();

		originalPosition = rbxposition.transform.localPosition;
		tempPosition = originalPosition;

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
			if(!(rbxposition.transform.localPosition.x <= .18 && rbxposition.transform.localPosition.x >= -.18)){
				rbxposition.transform.localPosition = tempPosition;
			}
			rbxposition.transform.localPosition = Vector3.Lerp(rbxposition.transform.localPosition, originalPosition, 0.5f * Time.deltaTime);
		 }

		if(rbxposition.transform.localPosition.x >= 0.18 || rbxposition.transform.localPosition.x <= -0.18)
		 {	
		 	//alex code
		 	if(rbxposition.transform.localPosition.x >= .18) {
		 		tempPosition = new Vector3(.18f,.22f,0);
		 		}
		 	else{
				tempPosition = new Vector3(-.18f,.22f,0);
		 	}
		 }
	
	}
}
