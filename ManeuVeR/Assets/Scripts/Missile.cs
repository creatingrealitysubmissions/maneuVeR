using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //public AudioClip[] noises = new AudioClip[4];
    AudioSource audioSource;

    public Rigidbody projectile;
    public Transform barrel;

    public GameObject target;

    private float dist;
    public float delay = 0;

    public float nextfire = 0.0f;
    public float fireSpeed = 10.0f;

    //Homing hom = new Homing();

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(target.transform.position, transform.position);
        //Debug.Log(dist);

        if (dist <= 500.0f && Time.time > nextfire)
        {
            StartCoroutine(DelayShot());
            
            nextfire = Time.time + fireSpeed;

        }
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(delay);
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(projectile, barrel.position, barrel.rotation) as Rigidbody;
        audioSource.Play();
        //audioSource.PlayOneShot(noises[Random.Range(0, 3)], 1.0f);


        //target = projectileInstance.gameObject.GetComponent<Homing>().target;
        //projectileInstance.AddForce(barrel.forward * 1000);


    }
}