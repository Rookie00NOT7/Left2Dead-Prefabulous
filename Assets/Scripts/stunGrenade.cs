using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunGrenade : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;
    private float thrust = 15.0f;
    private float time = 2f;
    private float timeToDestroy = 5f;
    public GameObject StunArea;
    private bool played;
    public AudioClip audioClip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        played = false;
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rb.AddForce(cam.transform.forward * thrust, ForceMode.Impulse);
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeToDestroy -= Time.deltaTime;
        if (time <= 0f && !played)
        {
            Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);
            GameObject effect = Instantiate(StunArea, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), spawnRotation);
            effect.GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(audioClip);
            played = true;
        }

        if(timeToDestroy <= 0f) Destroy(this.gameObject);
    }
}
