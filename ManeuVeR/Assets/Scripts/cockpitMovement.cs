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
	private int count = 0;
	// Use this for initialization
	void Start () {
	//	rbxrotation = shifter.GetComponent<Rigidbody>();
		rbxposition = this.GetComponent<Rigidbody>();

		originalPosition = rbxposition.transform.localPosition;

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

			if(count >= 1)
			{
				count = 0;
				rbxposition.transform.localPosition = tempPosition;
			}

			rbxposition.transform.localPosition = Vector3.Lerp(rbxposition.transform.localPosition, originalPosition, 0.5f * Time.deltaTime);
		 }

		if(rbxposition.transform.localPosition.x >= 0.18 || rbxposition.transform.localPosition.x <= -0.18)
		 {	
			if(count >= 0)
		 	{
		 		tempPosition = rbxposition.transform.localPosition;
		 		count++;
		 	}
		
			rbxposition.transform.localPosition = Vector3.Lerp(rbxposition.transform.localPosition, originalPosition, 0.5f * Time.deltaTime);
		 }
	
	}
}
