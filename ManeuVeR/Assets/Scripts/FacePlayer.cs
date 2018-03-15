using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {
    public Transform target;

    public float speed;
    public bool moveToward = false;
    public bool grounded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tempPos = transform.position;

        transform.LookAt(target);
        float step = speed * Time.deltaTime;
        if(moveToward == true)
        {
            if(grounded == true)
            {
                if(transform.position.y >= 0.0f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - tempPos.y, transform.position.z); 
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
	}
	void OnTriggerEnter(Collider col){
		if(col.attachedRigidbody.gameObject.tag == "Player"){
			moveToward = false;
		}
	}



	void OnTriggerExit(Collider col){
		if(col.attachedRigidbody.gameObject.tag == "Player"){
			moveToward = true;
		}
	}
}
