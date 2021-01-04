using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EllieBehavior : MonoBehaviour
{
    private GameObject player;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;
    private GameObject gun;
    private float time = 0.0f;
    private AudioSource audio;
    public AudioClip gunShotClip;
    private int rounds = 15;

    void killCount()
    {
        bool ammo = player.GetComponent<PlayerAddedBehavior>().killCount();
        if (ammo)
        {
            rounds += 15;
            rounds = Mathf.Clamp(rounds, 0, 45);
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
        gun = GameObject.FindGameObjectWithTag("ElliePistol");
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
            agent.speed = 3.5f;
        }
        else
        {
            anim.SetBool("run", false);
            if ((Vector3.Distance(player.transform.position, transform.position) > 7f))
            {
                agent.SetDestination(player.transform.position);
                anim.SetBool("walk", true);
                agent.speed = 2;
            }
            else
            {
                anim.SetBool("walk", false);
                agent.SetDestination(transform.position);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && rounds > 0)
        {
            Transform target = null;
            GameObject[] chargers = GameObject.FindGameObjectsWithTag("charger");
            if (chargers.Length > 0)
            {
                target = nearest(chargers);
                Vector3 delta = new Vector3(target.position.x - this.gameObject.transform.position.x, 0.0f, target.position.z - this.gameObject.transform.position.z);
                Quaternion rotation = Quaternion.LookRotation(delta);
                gameObject.transform.rotation = rotation;
                audio.PlayOneShot(gunShotClip);
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),
                    new Vector3(target.position.x - this.gameObject.transform.position.x, target.position.y - this.gameObject.transform.position.y, target.position.z - this.gameObject.transform.position.z), out hit))
                {
                    if (hit.transform.tag == "target")
                    {
                        bool kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(36);
                        if (kill)
                        {
                            killPlus();
                        }
                    }
                    else
                    {
                        if (hit.transform.tag == "spitter")
                        {
                            bool kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(36);
                            if (kill)
                            {
                                killPlus();
                            }
                        }
                        else
                        {
                            if (hit.transform.tag == "charger")
                            {
                                bool kill = hit.collider.gameObject.GetComponent<ChargerControlScript>().takeDamage(36);
                                if (kill)
                                {
                                    killPlus();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                GameObject[] spitters = GameObject.FindGameObjectsWithTag("spitter");
                if (spitters.Length > 0)
                {
                    target = nearest(spitters);
                    Vector3 delta = new Vector3(target.position.x - this.gameObject.transform.position.x, 0.0f, target.position.z - this.gameObject.transform.position.z);
                    Quaternion rotation = Quaternion.LookRotation(delta);
                    gameObject.transform.rotation = rotation;
                    audio.PlayOneShot(gunShotClip);
                    RaycastHit hit;
                    if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),
                        new Vector3(target.position.x - this.gameObject.transform.position.x, target.position.y - this.gameObject.transform.position.y, target.position.z - this.gameObject.transform.position.z), out hit))
                    {
                        if (hit.transform.tag == "target")
                        {
                            bool kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(36);
                            if (kill)
                            {
                                killPlus();
                            }
                        }
                        else
                        {
                            if (hit.transform.tag == "spitter")
                            {
                                bool kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(36);
                                if (kill)
                                {
                                    killPlus();
                                }
                            }
                            else
                            {
                                if (hit.transform.tag == "charger")
                                {
                                    bool kill = hit.collider.gameObject.GetComponent<ChargerControlScript>().takeDamage(36);
                                    if (kill)
                                    {
                                        killPlus();
                                    }
                                }
                            }
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
                            if (hit.transform.tag == "target")
                            {
                                bool kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(36);
                                if (kill)
                                {
                                    killPlus();
                                }
                            }
                            else
                            {
                                if (hit.transform.tag == "spitter")
                                {
                                    bool kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(36);
                                    if (kill)
                                    {
                                        killPlus();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (target != null)
            {
                time = 1.1f;
                gun.active = true;
                anim.SetTrigger("shoot");
                if(!player.GetComponent<PlayerAddedBehavior>().getRageMode())
                    rounds--;
            }
        }

        if (time <= 0f)
        {
            gun.active = false;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
