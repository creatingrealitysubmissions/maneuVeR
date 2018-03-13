﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public Transform target;
    private float rocketTurnSpeed;
    private float rocketSpeed;
    private float randomOffset;

    private float timerSinceLaunch;
    private float objectLifeTimerValue;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rocketTurnSpeed = 50.0f;
        rocketSpeed = 45f;
        randomOffset = 0.0f;

        timerSinceLaunch = 0;
        objectLifeTimerValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timerSinceLaunch += Time.deltaTime;

        if (target != null)
        {
            if (timerSinceLaunch > 1)
            {
                if ((target.position - transform.position).magnitude > 50)
                {
                    randomOffset = 100.0f;
                    rocketTurnSpeed = 90.0f;
                    //rb.angularVelocity = rocketTurnSpeed;

                }
                else
                {
                    randomOffset = 5f;
                    //if close to target
                    if ((target.position - transform.position).magnitude < 10)
                    {
                        rocketTurnSpeed = 180.0f;
                    }
                }
            }

            Vector3 direction = target.position - transform.position + Random.insideUnitSphere * randomOffset;
            direction.Normalize();
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), rocketTurnSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * rocketSpeed * Time.deltaTime);
        }

        if (timerSinceLaunch > objectLifeTimerValue)
        {
            Destroy(transform.gameObject, 1);
        }
    }
}
