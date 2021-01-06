﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeBombBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;
    private float thrust = 15.0f;
    private float time = 4f;
    public GameObject explosion;
    private GameObject[] targets;
    private GameObject[] spitters;
    private GameObject[] chargers;
    private GameObject[] tanks;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rb.AddForce(cam.transform.forward * thrust, ForceMode.Impulse);
        targets = GameObject.FindGameObjectsWithTag("target");
        spitters = GameObject.FindGameObjectsWithTag("spitter");
        chargers = GameObject.FindGameObjectsWithTag("charger");
        tanks = GameObject.FindGameObjectsWithTag("Tank");
    }

    void Update()
    {
        time -= Time.deltaTime;
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].GetComponent<ZombieController>().distract(this.gameObject);
        }
        for (int i = 0; i < spitters.Length; i++)
        {
            spitters[i].GetComponent<spitterController>().distract(this.gameObject);
        }
        for (int i = 0; i < chargers.Length; i++)
        {
            chargers[i].GetComponent<ChargerControlScript>().distract(this.gameObject);
        }
        for (int i = 0; i < tanks.Length; i++)
        {
            tanks[i].GetComponent<TankController>().distract(this.gameObject);
        }
        if (time <= 0f)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].GetComponent<ZombieController>().unDistract();
            }
            for (int i = 0; i < spitters.Length; i++)
            {
                spitters[i].GetComponent<spitterController>().unDistract();
            }
            for (int i = 0; i < chargers.Length; i++)
            {
                chargers[i].GetComponent<ChargerControlScript>().unDistract();
            }
            for (int i = 0; i < tanks.Length; i++)
            {
                tanks[i].GetComponent<TankController>().unDistract();
            }
            Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);
            GameObject effect = Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), spawnRotation);
            effect.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
        }
    }
}
