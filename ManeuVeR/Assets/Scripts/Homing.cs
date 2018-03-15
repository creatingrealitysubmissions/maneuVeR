using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Homing : MonoBehaviour {

    //public Transform target;
    public GameObject target;
    public GameObject explosion;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private float dist;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        //target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() //fixedupdate for bracket method
    {
        /*
        float step = speed * Time.deltaTime;
        */
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);

        Vector3 direction = target.transform.position - rb.position;
        direction.Normalize();
        Vector3 rotateAmount = Vector3.Cross(transform.right, direction);
        rb.angularVelocity = rotateAmount * rotateSpeed;
        rb.velocity = transform.right * speed;

        dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist <= 100)
        {
            //rb.velocity = rb.velocity + new Vector3(20.0f, 20.0f, 20.0f);
        }

        /*
        
       
        */
        //rb.AddForce(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));

    }

    void OnTriggerEnter()
    {
        // Eventually put a particle effect here
        //Instantiate(explosion, transform.position, transform.rotation);
        //Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
