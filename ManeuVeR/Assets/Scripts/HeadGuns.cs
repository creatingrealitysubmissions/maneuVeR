
using UnityEngine;

public class HeadGuns : MonoBehaviour {

    public float damage = 1f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            muzzleFlash.Play();

            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
