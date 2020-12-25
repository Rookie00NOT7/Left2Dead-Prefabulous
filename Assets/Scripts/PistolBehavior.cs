using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehavior : MonoBehaviour
{
    private Animator anim;
    public GameObject MuzzleFire;
    private AudioSource audio;
    public AudioClip clip;
    private int clipCap = 15;
    private GameObject cam;
    private float time = 1f; 

    public int getClipCap()
    {
        return clipCap;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (time <= 1f)
        {
            time += Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && clipCap > 0 && time >= 0.2f)
        {
            time = 0f;
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.transform.tag == "target" || hit.transform.tag == "specialTarget")
                {
                    hit.collider.gameObject.GetComponent<ZombieController>().takeDamage(36);
                }
            }
            anim.SetTrigger("Fire");
            Vector3 muzzlePos = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z + 0.1f);
            GameObject particles = Instantiate(MuzzleFire, muzzlePos, transform.rotation);
            particles.GetComponent<ParticleSystem>().Play();
            audio.PlayOneShot(clip);
            clipCap--;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            clipCap = 15;
            anim.SetTrigger("Reload");
        }
    }
}
