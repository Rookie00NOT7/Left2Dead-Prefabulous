
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class louisBehaviour : MonoBehaviour
{
    private GameObject player;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;
    private float time = 1.0f;
    private AudioSource audio;
    public AudioClip gunShotClip;
    private int rounds = 50;

    public void addAmmo()
    {
        rounds += 50;
        rounds = Mathf.Clamp(rounds, 0, 200);
    }

    void killCount()
    {
        bool ammo = player.GetComponent<PlayerAddedBehavior>().killCount();
        if (ammo)
        {
            rounds += 50;
            rounds = Mathf.Clamp(rounds, 0, 200);
        }
    }
    void killPlus()
    {
        player.GetComponent<PlayerAddedBehavior>().killPlus();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    
    Transform nearest(GameObject[] enemies)
    {
        float nearestSoFar = Mathf.Infinity;
        Transform ret = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
            if (distance < nearestSoFar)
            {
                ret = enemies[i].transform;
                nearestSoFar = distance;
            }
        }
        return ret;
    }

    void Update()
    {
        killCount();
        if (Vector3.Distance(player.transform.position, transform.position) > 10f)
        {
            agent.SetDestination(player.transform.position);
            anim.SetBool("run", true);
            agent.speed = 5f;
        }
        else
        {
            anim.SetBool("run", false);
            if ((Vector3.Distance(player.transform.position, transform.position) > 7f))
            {
                agent.SetDestination(player.transform.position);
                anim.SetBool("walk", true);
                agent.speed = 3;
            }
            else
            {
                anim.SetBool("walk", false);
                agent.SetDestination(transform.position);
            }
        }

        if (time <= 1f)
        {
            time += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q) && rounds > 0 && time >= 0.1f)
        {
            time = 0f;
            Transform target = null;
            GameObject[] chargers = GameObject.FindGameObjectsWithTag("charger");
            GameObject[] spitters = GameObject.FindGameObjectsWithTag("spitter");
            GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
            GameObject[] boomers = GameObject.FindGameObjectsWithTag("boomer");
            GameObject[] specials = ((chargers.Concat(spitters).ToArray()).Concat(tanks).ToArray()).Concat(boomers).ToArray();

            if (specials.Length > 0)
            {
                target = nearest(specials);
                Vector3 delta = new Vector3(target.position.x - this.gameObject.transform.position.x, 0.0f, target.position.z - this.gameObject.transform.position.z);
                Quaternion rotation = Quaternion.LookRotation(delta);
                gameObject.transform.rotation = rotation;
                audio.PlayOneShot(gunShotClip);
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),
                    new Vector3(target.position.x - this.gameObject.transform.position.x, target.position.y - this.gameObject.transform.position.y, target.position.z - this.gameObject.transform.position.z), out hit))
                {
                    string hitTag = hit.transform.tag;
                    bool kill = false;
                    switch (hitTag)
                    {
                        case "target": kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(33); break;
                        case "spitter": kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(33); break;
                        case "charger": kill = hit.collider.gameObject.GetComponent<ChargerControlScript>().takeDamage(33); break;
                        case "Tank": kill = hit.collider.gameObject.GetComponent<TankController>().takeDamage(33); break;
                        case "boomer": kill = hit.collider.gameObject.GetComponent<boomerController>().takeDamage(33); break;
                    }
                    if (kill)
                    {
                        killPlus();
                    }
                }
            }
            else
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("target");
                if (enemies.Length > 0)
                {
                    target = nearest(enemies);
                    Vector3 delta = new Vector3(target.position.x - this.gameObject.transform.position.x, 0.0f, target.position.z - this.gameObject.transform.position.z);
                    Quaternion rotation = Quaternion.LookRotation(delta);
                    gameObject.transform.rotation = rotation;
                    audio.PlayOneShot(gunShotClip);
                    RaycastHit hit;
                    Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                    Debug.DrawRay(transform.position, forward, Color.green);
                    if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),
                        new Vector3(target.position.x - this.gameObject.transform.position.x, target.position.y - this.gameObject.transform.position.y, target.position.z - this.gameObject.transform.position.z), out hit))
                    {
                        string hitTag = hit.transform.tag;
                        bool kill = false;
                        switch (hitTag)
                        {
                            case "target": kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(33); break;
                            case "spitter": kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(33); break;
                            case "charger": kill = hit.collider.gameObject.GetComponent<ChargerControlScript>().takeDamage(33); break;
                            case "Tank": kill = hit.collider.gameObject.GetComponent<TankController>().takeDamage(33); break;
                            case "boomer": kill = hit.collider.gameObject.GetComponent<boomerController>().takeDamage(33); break;
                        }
                        if (kill)
                        {
                            killPlus();
                        }
                    }
                }
            }
            if (target != null)
            {
                anim.SetTrigger("fire");
                if (!player.GetComponent<PlayerAddedBehavior>().getRageMode())
                    rounds--;
                Debug.Log(rounds);
            }
        }
    }
}
