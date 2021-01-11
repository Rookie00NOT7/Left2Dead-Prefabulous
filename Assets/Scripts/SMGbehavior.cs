using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGbehavior : MonoBehaviour
{
    private Animator anim;
    public GameObject MuzzleFire;
    private AudioSource audio;
    public AudioClip fireClip;
    public AudioClip reloadClip;
    private int clipCap = 50;
    private int ammo = 700;
    private GameObject cam;
    private float time = 1f;
    private PlayerAddedBehavior player;


    public int getClipCap()
    {
        return clipCap;
    }

    public int getAmmo() {
        return ammo;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAddedBehavior>();
    }

    public void takeAmmo(int ammoLooted)
    {
        ammo += ammoLooted;
        ammo = Mathf.Clamp(ammo, 0, 700);
    }
    void Update()
    {
        if (time <= 1f)
        {
            time += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0) && clipCap > 0 && time >= 0.06f)
        {
            bool rage = player.getRageMode();
            time = 0f;
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.transform.tag == "target")
                {
                    string tag = hit.transform.tag;
                    bool kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(20 * ((rage) ? 2 : 1));
                    if (kill)
                    {
                        player.killPlus();
                        player.rage(tag);
                    }
                }
                else
                {
                    if (hit.transform.tag == "spitter")
                    {
                        string tag = hit.transform.tag;
                        bool kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(20 * ((rage) ? 2 : 1));
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
                            bool kill = hit.collider.gameObject.GetComponent<ChargerControlScript>().takeDamage(20 * ((rage) ? 2 : 1));
                            if (kill)
                            {
                                player.killPlus();
                                player.rage(tag);
                            }
                        }
                        else
                        {
                            if (hit.transform.tag == "Tank")
                            {
                                string tag = hit.transform.tag;
                                bool kill = hit.collider.gameObject.GetComponent<TankController>().takeDamage(20 * ((rage) ? 2 : 1));
                                if (kill)
                                {
                                    player.killPlus();
                                    player.rage(tag);
                                }
                            }
                             else
                        {
                            if (hit.transform.tag == "boomer")
                            {
                                string tag = hit.transform.tag;
                                bool kill = hit.collider.gameObject.GetComponent<boomerController>().takeDamage(20 * ((rage) ? 2 : 1));
                                if (kill)
                                {
                                    player.killPlus();
                                    player.rage(tag);
                                }
                            }
                        }
                        }
                    }
                }
            }
            anim.SetBool("fire", true);
            Vector3 muzzlePos = new Vector3(transform.position.x, transform.position.y + 0.07f, transform.position.z - 0.5f);
            GameObject particles = Instantiate(MuzzleFire, muzzlePos, transform.rotation);
            particles.GetComponent<ParticleSystem>().Play();
            audio.PlayOneShot(fireClip);
            clipCap--;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("fire", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo > 0)
            {
                if (ammo >= 50)
                {
                    int added = 50 - clipCap;
                    clipCap = 50;
                    ammo -= added;
                }
                else
                {
                    clipCap = ammo;
                    ammo = 0;
                }
                anim.SetTrigger("reload");
                audio.PlayOneShot(reloadClip);
            }
        }
    }
}
