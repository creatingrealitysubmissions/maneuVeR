using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public AudioSource audioSource;
	public GameObject camera;

    public GameObject explosion;
    public Rigidbody projectile;
    public Transform barrel;

    public GameObject leftController;
    public GameObject rightController;

    private bool left = false;

    public float nextfire = 0.0f;
    public float fireSpeed = .33f;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		if(this.tag == leftController.tag){
			left = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	if(left)
	{
			if (leftController.GetComponent<ControllerGrabObject>().fire && Time.time > nextfire)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, barrel.position, camera.transform.rotation) as Rigidbody;
            projectileInstance.AddForce(camera.transform.forward * 10000);
            audioSource.Play();
            nextfire = Time.time + fireSpeed;
        }
	}
		if(!left){
			if (rightController.GetComponent<ControllerGrabObject>().fire && Time.time > nextfire)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, barrel.position, barrel.rotation) as Rigidbody;
            projectileInstance.AddForce(barrel.forward * 10000);
				audioSource.Play();
            nextfire = Time.time + fireSpeed;
        }
	}
 
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
