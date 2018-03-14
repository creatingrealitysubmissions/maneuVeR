using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignGearValue : MonoBehaviour {

	public float gearValue;
	// Use this for initialization
	void Start () {
		if(this.gameObject.tag == "F4") {
			gearValue = 1;
		}
		else if(this.gameObject.tag == "F3") {
			gearValue = .75f;
		}
		else if(this.gameObject.tag == "F2") {
			gearValue = .50f;
		}
		else if(this.gameObject.tag == "F1") {
			gearValue = .0f;
		}
		else if(this.gameObject.tag == "Neu") {
			gearValue = .0f;
		}
		else if(this.gameObject.tag == "B1") {
			gearValue = 0f;
		}
		else if(this.gameObject.tag == "B2") {
			gearValue = -.50f;
		}
		else if(this.gameObject.tag == "B3") {
			gearValue = -.75f;
		}
		else if(this.gameObject.tag == "B4") {
			gearValue = -1f;
		}
	}
	


	void OnTriggerEnter(Collider other){
		if(other.attachedRigidbody.gameObject.tag == "LShift" || other.attachedRigidbody.gameObject.tag == "RShift") {
			other.attachedRigidbody.gameObject.GetComponent<thrustAllignment>().currentGear = gearValue;

		}

	}
}
