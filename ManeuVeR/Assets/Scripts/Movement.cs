using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Rigidbody leftThrust;

	public Rigidbody rightThrust;

	private GameObject Player;

	public float maxSpeed;

	public float currentGearL;

	public float currentGearR;

	private float difference;



	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("World");



		currentGearL = leftThrust.gameObject.GetComponent<thrustAllignment>().currentGear;
		currentGearR = rightThrust.gameObject.GetComponent<thrustAllignment>().currentGear;

	}



	// Update is called once per frame
	void Update () 
	{
		
		currentGearL = leftThrust.gameObject.GetComponent<thrustAllignment>().currentGear;
		currentGearR = rightThrust.gameObject.GetComponent<thrustAllignment>().currentGear;
		//if the gears are going in the same direction
		Debug.Log("Left gear is " + currentGearL + " and Right gear is "+ currentGearR);
		if(currentGearL == currentGearR)
		{
			//forward
			if(currentGearL > 0f)
			{
				Player.transform.position += Vector3.left * (currentGearL * maxSpeed);
			}
			// backward
			if(currentGearL < 0f)
			{
				Player.transform.position += Vector3.right * ((currentGearL * -1f) * maxSpeed);
			}
			//netural
			if(currentGearL == 0f)
			{
				//Player.transform.position += Vector3.zero;
			}
		}
		//if both positve but not the same
		else if(currentGearL > 0f && currentGearR > 0f)
		{
			difference = currentGearL - currentGearR;

			//forward and left 
			if(difference >= 0f)
			{
				Player.transform.position += Vector3.left * (difference * maxSpeed);


				Player.transform.Rotate(Vector3.back * (difference * maxSpeed));
			}
			//forward and right 
			if(difference <= 0f)
			{
				Player.transform.position += Vector3.left * ((-1f * difference) * maxSpeed);

				Player.transform.Rotate(Vector3.forward* ((-1f*difference) * maxSpeed));
			}
		}
		//if both negative but not the same
		else if(currentGearL < 0f && currentGearR < 0f)
		{
			//backward and left
			if(difference >= 0f)
			{
				Player.transform.position += Vector3.right * (difference * maxSpeed);
			
				Player.transform.Rotate( Vector3.back * (difference * maxSpeed));
			}

			//backward and right
			if(difference <= 0f)
			{
				Player.transform.position += Vector3.right * ((-1f * difference) * maxSpeed);

				Player.transform.Rotate(Vector3.forward * ((-1f*difference) * maxSpeed));
			}

		}
		//right 
		else if (currentGearL < 0f && currentGearR > 0f)
		{
			difference = currentGearL - currentGearR;

			if(difference < 0f)
			{
				difference *= -1.0f;
			}


			Player.transform.Rotate(Vector3.forward * (difference * maxSpeed));
		} 
		//left
		else if(currentGearL > 0f && currentGearR < 0f)
		{
			difference = currentGearL - currentGearR;

			if(difference < 0f)
			{
				difference *= -1.0f;
			}

			Player.transform.Rotate(Vector3.back * (difference * maxSpeed));

		}


	
	//MOVING FORWAD ONLY IF STATEMENTS
	//if the thrusters are in idle position 
	/*
		if((leftThrust.transform.localPosition.z >=-0.044f && leftThrust.transform.localPosition.z <= 0.044f) && (rightThrust.transform.localPosition.z >= -.044f && rightThrust.transform.localPosition.z <=0.044f))
		{
			Player.freezeRotation = true;
			//no force is being added because gear in neutral 
			Debug.Log("O% Thrust");
		}

		if((leftThrust.transform.localPosition.z >=0.044f && leftThrust.transform.localPosition.z <= 0.088f) && (rightThrust.transform.localPosition.z >= .044f && rightThrust.transform.localPosition.z <=0.088f))
		{
			Player.freezeRotation = true;
			Player.AddForce(transform.forward *.25f*maxSpeed,ForceMode.Force); 
			//TimeInterval();
			Debug.Log("25% Thrust");
		}
		if((leftThrust.transform.localPosition.z >=0.088f && leftThrust.transform.localPosition.z <= 0.132f) && (rightThrust.transform.localPosition.z >= .088f && rightThrust.transform.localPosition.z <=0.132f))
		{
			Player.freezeRotation = true;
			Player.AddForce(transform.forward *.50f*maxSpeed,ForceMode.Force); 
			//TimeInterval();
			Debug.Log("50% Thrust");
		}
		 if((leftThrust.transform.localPosition.z >=0.132f && leftThrust.transform.localPosition.z <= 0.176f) && (rightThrust.transform.localPosition.z >= .132f && rightThrust.transform.localPosition.z <=0.176f))
		{
			Player.freezeRotation = true;
			Player.AddForce(transform.forward *.75f*maxSpeed,ForceMode.Force); 
			//TimeInterval();
			Debug.Log("75% Thrust");
		}
		if((leftThrust.transform.localPosition.z >=0.176f && leftThrust.transform.localPosition.z <= 0.22f) && (rightThrust.transform.localPosition.z >= .176f && rightThrust.transform.localPosition.z <=0.22f))
		{
			Player.freezeRotation = true;
			Player.AddForce(transform.forward *maxSpeed,ForceMode.Force); 
			//TimeInterval();
			Debug.Log("100% Thrust");
		}
		*/
	}
}
