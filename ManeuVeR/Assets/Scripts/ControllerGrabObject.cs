﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

private SteamVR_TrackedObject trackedObj;
private GameObject collidingObject;
private GameObject objectInHand;

public bool fire = false;
public bool fly = false;

private SteamVR_Controller.Device Controller
{
	get{ return SteamVR_Controller.Input((int)trackedObj.index);}
}

void Awake()
{
	trackedObj = GetComponent<SteamVR_TrackedObject>();
}

private void SetCollidingObject(Collider col)
{
	if(collidingObject || !col.GetComponent<Rigidbody>())
	{
		return;
	}
	collidingObject = col.gameObject;
}

public void OnTriggerEnter(Collider other)
{
	SetCollidingObject(other);
}

public void OnTriggerStay(Collider other)
{
	SetCollidingObject(other);
}

public void OnTriggerExit(Collider other)
{
	if(!collidingObject)
	{
		return;
	}
	collidingObject = null;
}

private void GrabObject()
{
	objectInHand = collidingObject;
	collidingObject = null;
	if(objectInHand.tag =="LThrust" || objectInHand.tag == "RThrust") {
		objectInHand.GetComponent<cockpitMovement>().grabed = true;
	 } 
	var joint = AddFixedJoint();

	joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
}

private FixedJoint AddFixedJoint()
{
	FixedJoint fx = gameObject.AddComponent<FixedJoint>();
	fx.breakForce = 20000;
	fx.breakTorque = 20000;
	return fx;
}

private void ReleaseObject()
{
	if(GetComponent<FixedJoint>())
	{
		GetComponent<FixedJoint>().connectedBody = null;
		Destroy(GetComponent<FixedJoint>());
		if(!(objectInHand.tag.Equals("LThrust")) || !(objectInHand.tag.Equals("RThrust")))
		{
			objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
		}
	}
		if (objectInHand.tag =="LThrust" || objectInHand.tag == "RThrust") {
			objectInHand.GetComponent<cockpitMovement>().grabed= false;
	}
	objectInHand = null;
}

	void Update ()
	{
		if(Controller.GetHairTriggerDown())
		{
			if(collidingObject)
			{
				GrabObject();
			}
	
		}

		if(Controller.GetHairTriggerUp())
		{
			if(objectInHand)
			{
				ReleaseObject();
			}
		}
		if(Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
				fire =true;
			}
			if(Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
				fly = true;
			}
			if(Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
				fire =false;
			}
			if(Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
				fly = false;
			}

	}

	public bool returnFly()
	{
		return fly; 
	}
}
