using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesHandler : MonoBehaviour
{
    private GameObject assault;
    private GameObject huntingRifle;
    private GameObject SMG;
    private GameObject shotgun;
    private GameObject molotov;
    private GameObject pipeBomb;
    private GameObject stunGrenade;
    private weaponManager weaponMan;

    private AudioSource audio;
    public AudioClip gunsSound;
    public AudioClip grenadesSound;

    private float maxAngularSpeed = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        assault = GameObject.FindGameObjectWithTag("Assault");
        huntingRifle = GameObject.FindGameObjectWithTag("HuntingRifle");
        shotgun = GameObject.FindGameObjectWithTag("Shotgun");
        SMG = GameObject.FindGameObjectWithTag("SMG");
        pipeBomb = GameObject.FindGameObjectWithTag("PipeBomb");
        molotov = GameObject.FindGameObjectWithTag("Molotov");
        stunGrenade = GameObject.FindGameObjectWithTag("Stun");
        weaponMan = GameObject.FindGameObjectWithTag("FPCamera").GetComponent<weaponManager>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(assault!=null){
           assault.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,maxAngularSpeed);
            if (Vector3.Distance(assault.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E)){
                weaponMan.collect(4);
                assault.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(assault.gameObject,2f);
            }
        }
        if(huntingRifle!=null){
            huntingRifle.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,maxAngularSpeed);
            if (Vector3.Distance(huntingRifle.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E)){
                weaponMan.collect(3);
                huntingRifle.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(huntingRifle.gameObject,2f);
            }
        }
        if(shotgun!=null){
            shotgun.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,maxAngularSpeed);
            if (Vector3.Distance(shotgun.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E)){
                weaponMan.collect(2);
                shotgun.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(shotgun.gameObject,2f);
            }
        }
        if(SMG!=null){
            SMG.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,maxAngularSpeed,0);
            if (Vector3.Distance(SMG.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E)){
                weaponMan.collect(1);
                SMG.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(SMG.gameObject,2f);
            }
        }
        if(pipeBomb!=null){
            pipeBomb.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,maxAngularSpeed,0);
            if (Vector3.Distance(pipeBomb.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E)){
                GetComponent<grenades>().addPipe(1);
                pipeBomb.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(grenadesSound);
                Destroy(pipeBomb.gameObject,2f);
            }
        }
        if(molotov!=null){
            molotov.GetComponent<Rigidbody>().angularVelocity = new Vector3(maxAngularSpeed,0,0);
            if (Vector3.Distance(molotov.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E)){
                GetComponent<grenades>().addMol(1);
                molotov.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(grenadesSound);
                Destroy(molotov.gameObject,2f);
            }
        }
        if(stunGrenade!=null){
            stunGrenade.GetComponent<Rigidbody>().angularVelocity = new Vector3(maxAngularSpeed,0,0);
            if (Vector3.Distance(stunGrenade.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E)){
                GetComponent<grenades>().addStun(1);
                stunGrenade.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(grenadesSound);
                Destroy(stunGrenade.gameObject,2f);
            }
        }
   
    }
}
