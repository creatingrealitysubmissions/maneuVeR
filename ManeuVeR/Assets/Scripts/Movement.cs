using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Rigidbody leftThrust;

	public Rigidbody rightThrust;

	private GameObject Player;

	public float maxSpeed;

	public float jetSpeed;

	public float currentGearL;

	public float currentGearR;

	private float difference;

	public GameObject leftCollider;

	public GameObject rightCollider;

	public GameObject leftHand;

	public GameObject rightHand;


	public float fallspeed;
	private bool flyL = false;
	private bool flyR = false;

	private bool stabalize = false;
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

		flyL = leftHand.GetComponent<ControllerGrabObject>().returnFly();
		flyR = rightHand.GetComponent<ControllerGrabObject>().returnFly();

		//if the gears are going in the same direction
		Debug.Log("Left gear is " + currentGearL + " and Right gear is "+ currentGearR);
		if(flyL || flyR) {

			Debug.Log("FlyR:" + flyR + "---------FlyL:" + flyL);
			if(flyL && flyR) {
				Player.transform.position += Vector3.down * jetSpeed;
				stabalize =false;
			}
			else {
				Player.transform.position = Player.transform.position;
				stabalize =true;
			}
		}
		else {
			stabalize =false;
		}

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
				Player.transform.position = Player.transform.position;
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
		else if (currentGearL <= 0f && currentGearR >= 0f)
		{
			difference = currentGearL - currentGearR;

			if(difference < 0f)
			{
				difference *= -1.0f;
			}


			Player.transform.Rotate(Vector3.forward * (difference * maxSpeed));
		} 
		//left
		else if(currentGearL >= 0f && currentGearR <= 0f)
		{
			difference = currentGearL - currentGearR;

			if(difference < 0f)
			{
				difference *= -1.0f;
			}

			Player.transform.Rotate(Vector3.back * (difference * maxSpeed));

		}
		if (Player.transform.position.y < -5 && !stabalize) {
			Player.transform.position = Vector3.Lerp(Player.transform.position,new Vector3(Player.transform.position.x, -5f, Player.transform.position.z), fallspeed * Time.deltaTime);
			}
	

	}
}
