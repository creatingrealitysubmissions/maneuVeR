using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockpitMovement : MonoBehaviour {

	public bool grabed = false;
	public GameObject shifter;
	//public GameObject knob;
	private Rigidbody rbxrotation;
	private Rigidbody rbxposition;

	private float speed = 5.0f;

	private Vector3 originalPosition;
	private Vector3 handlePosition;
	private Vector3 tempPosition; 

	public Rigidbody originalHandlePosition;

	// Use this for initialization
	void Start () {
		rbxrotation = shifter.GetComponent<Rigidbody>();
		rbxposition = this.GetComponent<Rigidbody>();

		originalPosition = rbxposition.transform.localPosition;
		tempPosition = originalPosition;

		handlePosition = originalHandlePosition.transform.localPosition;

	}

	// Update is called once per frame
	void Update () 
	{
		if (grabed) 
		{

			rbxposition.isKinematic = false;
			rbxposition.useGravity = true;
			if(rbxposition.transform.localPosition.z >= 0.22 || rbxposition.transform.localPosition.z <= -0.22)
			 {	
			 	//alex code
			 	if(rbxposition.transform.localPosition.z >= .22) {
					handlePosition.z = .22f;
					rbxposition.velocity =Vector3.zero;
					rbxposition.angularVelocity = Vector3.zero;
					rbxrotation.transform.localPosition = Vector3.Lerp(rbxrotation.transform.localPosition,handlePosition,speed * Time.deltaTime);
				
			 		}
			 	else{

					handlePosition.z = -.22f;
					rbxposition.velocity =Vector3.zero;
					rbxposition.angularVelocity = Vector3.zero;
					rbxrotation.transform.localPosition = Vector3.Lerp(rbxrotation.transform.localPosition,handlePosition,speed * Time.deltaTime);
			 	}
		 	}
		 	else {

		 		handlePosition.z = rbxposition.transform.localPosition.z; 
		 		//handlePosition = new Vector3(0f,.15f,rbxposition.transform.localPosition.z);
				rbxposition.velocity =Vector3.zero;
					rbxposition.angularVelocity = Vector3.zero;
		 		rbxrotation.transform.localPosition = Vector3.Lerp(rbxrotation.transform.localPosition,handlePosition,speed * Time.deltaTime);
		}

		}

		if(!grabed)
		 {
			rbxposition.isKinematic = true;
			rbxposition.useGravity = false;
			if(!(rbxposition.transform.localPosition.z <= .22 && rbxposition.transform.localPosition.z >= -.22)){
				rbxposition.transform.localPosition = tempPosition;
			}
			rbxposition.transform.localPosition = Vector3.Lerp(rbxposition.transform.localPosition, originalPosition, 0.5f * Time.deltaTime);
			rbxrotation.transform.localPosition = new Vector3 (rbxrotation.transform.localPosition.x, rbxrotation.transform.localPosition.y,rbxposition.transform.localPosition.z);
		 }

		if(rbxposition.transform.localPosition.z >= 0.22 || rbxposition.transform.localPosition.z <= -0.22)
		 {	
		 	//alex code
		 	if(rbxposition.transform.localPosition.z >= .22) {
		 		tempPosition = new Vector3(0f,.15f,.22f);
		 		}
		 	else{
				tempPosition = new Vector3(0f,.15f,-.22f);
		 	}
		 }
	
	}
}

