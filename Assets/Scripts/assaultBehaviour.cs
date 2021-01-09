﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assaultBehaviour : MonoBehaviour
{
    private Animator anim;
    public GameObject MuzzleFire;
    private AudioSource audio;
    public AudioClip fireClip;
    public AudioClip reloadClip;
    private int clipCap = 15;
    private GameObject cam;
    private float time = 1f;
    private PlayerAddedBehavior player;
    private int totalBullets = 450;


    public int getClipCap()
    {
        return clipCap;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAddedBehavior>();
    }

    void Update()
    {
        if (time <= 1f)
        {
            time += Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.Mouse0) && clipCap > 0 && time >= 0.1f)
        {
            bool rage = player.getRageMode();
            time = 0f;
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.transform.tag == "target")
                {
                    string tag = hit.transform.tag;
                    bool kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(33 * ((rage)? 2:1));
                    if (kill)
                    {
                        player.killPlus();
                        player.rage(tag);
                    }
                }
                else
                {
                    if(hit.transform.tag == "spitter")
                    {
                        string tag = hit.transform.tag;
                        bool kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(33 * ((rage) ? 2 : 1));
                        if (kill)
                        {
                            player.killPlus();
                            player.rage(tag);
                        }
                    }
                    else
                    {
                        if (hit.transform.tag == "charger")
                        {
                            string tag = hit.transform.tag;
                            bool kill = hit.collider.gameObject.GetComponent<ChargerControlScript>().takeDamage(33 * ((rage) ? 2 : 1));
                            if (kill)
                            {
                                player.killPlus();
                                player.rage(tag);
                            }
                        }
                    }
                }
            }
            anim.SetTrigger("Fire");
            Vector3 muzzlePos = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z + 0.1f);
            GameObject particles = Instantiate(MuzzleFire, muzzlePos, transform.rotation);
            particles.GetComponent<ParticleSystem>().Play();
            audio.PlayOneShot(fireClip);
            clipCap--;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(totalBullets>0){  
                totalBullets-=(50-clipCap);
                clipCap = 50;
            }
            anim.SetTrigger("Reload");
            audio.PlayOneShot(reloadClip);
        }
    }
}
