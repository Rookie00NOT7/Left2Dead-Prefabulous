using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huntingRifleBehavior : MonoBehaviour
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
    private int totalBullets = 165;


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
        print(clipCap);
        if (time <= 1f)
        {
            time += Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && clipCap > 0 && time >= 0.25f)
        {
            bool rage = player.getRageMode();
            time = 0f;
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.transform.tag == "target" )
                {
                    string tag = hit.transform.tag;
                    bool kill = hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(90 * ((rage)? 2:1));
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
                        bool kill = hit.collider.gameObject.GetComponent<spitterController>().takeDamage(90 * ((rage) ? 2 : 1));
                        if (kill)
                        {
                            player.killPlus();
                            player.rage(tag);
                        }
                    }
                   
                }
            }
            anim.SetTrigger("fire");
            Vector3 muzzlePos = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z + 0.1f);
            GameObject particles = Instantiate(MuzzleFire, muzzlePos, transform.rotation);
            particles.GetComponent<ParticleSystem>().Play();
            audio.PlayOneShot(fireClip);
            if(clipCap>0)
                clipCap--;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(totalBullets>0){  
                totalBullets-=(15-clipCap);
                clipCap = 15;
            }
            anim.SetTrigger("reload");
            audio.PlayOneShot(reloadClip);
        }
    }
}
