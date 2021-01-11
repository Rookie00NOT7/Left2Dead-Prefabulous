using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;
    private GameObject temp;
    private Vector3 distraction;
    private AudioSource audio;
    private bool seen = false;
    private bool dead = false;
    private bool playOther = false;
    private bool distracted = false;
    private int i = 0;
    private float time = 0f;
    private float timeToDisappear = 10f;
    
    [Header ("Zombie Settings")]
    public int health = 1000;
    public int damage = 30;

    public Transform[] patrol;
    public AudioClip alertClip;
    
    public void setPlayer(GameObject thePlayer)
    {
        player = thePlayer;
    }

    public void setSeen()
    {
        seen = true;
        anim.SetTrigger("playerSeen");
        agent.speed = 5;
        if (!playOther)
        {
            playOther = true;
            audio.clip = alertClip;
            audio.Play();
        }
    }

    public bool takeDamage(int val)
    {
        health -= val;
        if (health <= 0)
        {
            transform.gameObject.tag = "dead";
            anim.SetTrigger("die");
            agent.enabled = false;
            dead = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            audio.Stop();
            return true;
        }
        else
        {
            anim.SetTrigger("Hit");
            agent.SetDestination(player.transform.position);
            seen = true;
            agent.speed = 5;
            if (!playOther)
            {
                playOther = true;
                audio.clip = alertClip;
                audio.Play();
            }
            return false;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        temp = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void distract(GameObject dist)
    {
        distraction = dist.transform.position;
        distracted = true;
        setSeen();
    }

    public void unDistract()
    {
        distracted = false;
    }

    void Update()
    {
        if(!seen && Vector3.Distance(player.transform.position, transform.position) < 20f && Input.GetKeyDown(KeyCode.Mouse0))
        {
            seen = true;
            anim.SetTrigger("playerSeen");
            agent.speed = 5;
            if (!playOther)
            {
                playOther = true;
                audio.clip = alertClip;
                audio.Play();
            }
        }

        if (seen && !dead)
        {
            if (!distracted)
            {
                if (Vector3.Distance(player.transform.position, transform.position) < 2f)
                {
                    agent.SetDestination(transform.position);
                    anim.SetTrigger("punch");
                    if (time >= 1f)
                    {
                        player.GetComponent<PlayerAddedBehavior>().takeDamage(damage);
                        time = 0f;
                    }
                    time += Time.deltaTime;
                }
                else
                {
                    agent.SetDestination(player.transform.position);
                }
            }
            else
            {
                if (Vector3.Distance(distraction, transform.position) < 2f)
                {
                    agent.SetDestination(transform.position);
                    anim.SetTrigger("punch");
                }
                else
                {
                    agent.SetDestination(distraction);
                }
            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    seen = true;
                    anim.SetTrigger("playerSeen");
                    agent.speed = 5;
                    if (!playOther)
                    {
                        playOther = true;
                        audio.clip = alertClip;
                        audio.Play();
                    }
                }
            }
        }

        if (!seen && !dead)
        {
            if (agent.remainingDistance <= 0.05 && patrol.Length != 0)
            {
                agent.SetDestination(patrol[i].position);
                i = (i + 1) % patrol.Length;
            }
        }

        if (dead)
        {
            timeToDisappear -= Time.deltaTime;
            if (timeToDisappear <= 0)
                Destroy(this.gameObject);
        }
    }
}