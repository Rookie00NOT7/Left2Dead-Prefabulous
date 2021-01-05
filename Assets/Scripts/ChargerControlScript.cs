using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChargerControlScript : MonoBehaviour
{
    private float timeToDisappear = 10f;
    private float time;
    public Transform[] patrol;
    private int i = 0;
    private GameObject player;
    private GameObject temp;
    private AudioSource audio;
    private NavMeshAgent agent;
    private Animator anim;
    private bool dead = false;
    private bool seen = false;
    private bool playOther = false;
    private int health;
    public AudioClip alertClip;
    private bool distracted = false;
    private Vector3 distraction ;
    private float pinDownDuration = 0f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        temp = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.Play();
        health = 600;
        time = 5f;
        
    }
     public bool takeDamage(int val)
    {
        health -= val;
        print(health);
        if (health <= 0)
        {
            anim.SetTrigger("die");
            transform.gameObject.tag = "dead";
            agent.enabled = false;
            dead = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            audio.Stop();
            return true;
        }
        else
        {
            agent.SetDestination(player.transform.position);
            seen = true;
            agent.speed = 15;
            if (!playOther)
            {
                playOther = true;
                audio.clip = alertClip;
                audio.Play();
            }
            return false;
        }
    }
    public void setSeen()
    {
        seen = true;
        agent.speed = 15;
        if (!playOther)
        {
            playOther = true;
            audio.clip = alertClip;
            audio.Play();
        }
    }
    public void unDistract()
    {
        distracted = false;
    }
    public void distract(GameObject dist)
    {
        distraction = dist.transform.position;
        distracted = true;
        setSeen();
    }
    
    void Update()
    {
        if(pinDownDuration > 0f)
        {
            player.GetComponent<CharacterController>().enabled = false;
            pinDownDuration -= Time.deltaTime;
        }
        else
        {
            player.GetComponent<CharacterController>().enabled = true;
            pinDownDuration = 0f;
        }
        if(!seen && Vector3.Distance(player.transform.position, transform.position) < 20f && Input.GetKeyDown(KeyCode.Mouse0))
        {
            seen = true;
            agent.speed = 15;
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
                if (time >= 5f)
                {
                    if (Vector3.Distance(player.transform.position, transform.position) < 3f)
                    {
                        Vector3 delta = new Vector3(player.transform.position.x - this.gameObject.transform.position.x, 0.0f, player.transform.position.z - this.gameObject.transform.position.z);
                        Quaternion rotation = Quaternion.LookRotation(delta);
                        gameObject.transform.rotation = rotation;
                        anim.SetTrigger("punch");
                        player.GetComponent<PlayerAddedBehavior>().takeDamage(75);
                        time = 0f;
                        pinDownDuration = 2f;
                    }
                    else
                    {
                        agent.SetDestination(player.transform.position);
                        anim.SetTrigger("trackAgain");
                    }
                }
                else
                {
                    anim.ResetTrigger("trackAgain");
                    time += Time.deltaTime;
                    agent.SetDestination(transform.position);
                }
            }
            else
            {
                if (time >= 5f)
                {
                    if (Vector3.Distance(distraction, transform.position) < 2f)
                    {
                        agent.SetDestination(transform.position);
                        anim.SetTrigger("punch");
                        time = 0f;
                    }
                    else
                    {
                        agent.SetDestination(distraction);
                        anim.SetTrigger("trackAgain");
                    }
                }
                else
                {
                    anim.ResetTrigger("trackAgain");
                    time += Time.deltaTime;
                    agent.SetDestination(transform.position);
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
