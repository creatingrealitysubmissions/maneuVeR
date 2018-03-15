using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour {

    public Rigidbody projectile;
    public Transform barrel;

    public float nextfire = 0.0f;
    public float fireSpeed = .33f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, barrel.position, barrel.rotation) as Rigidbody;
            projectileInstance.AddForce(barrel.forward * 1000);

            nextfire = Time.time + fireSpeed;
        }
    }
}
