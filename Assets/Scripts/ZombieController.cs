using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;
    private bool seen = false;
    private int health = 50;
    private bool dead = false;
    private float time = 0f;
    public Transform[] patrol;
    private int i = 0;
    private AudioSource audio;
    public AudioClip alertClip;
    private bool playOther = false;
    private float timeToDisappear = 10f;
    private GameObject temp;
    private bool distracted = false;
    private Vector3 distraction;

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

    void Awake()
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
                        player.GetComponent<PlayerAddedBehavior>().takeDamage(5);
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
            if (agent.remainingDistance <= 0.05)
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
