using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour {


    public GameObject explosion;
    public Rigidbody projectile;
    public Transform barrel;

    public GameObject target;

    private float dist;
    public float nextfire = 0.0f;
    public float fireSpeed = .33f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(target.transform.position, transform.position);
        //Debug.Log(dist);

        if (dist <= 500.0f && Time.time > nextfire)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, barrel.position, barrel.rotation) as Rigidbody;
            projectileInstance.AddForce(barrel.forward * 10000);

            nextfire = Time.time + fireSpeed;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
