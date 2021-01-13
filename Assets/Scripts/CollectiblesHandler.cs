using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesHandler : MonoBehaviour
{ 
    private AudioSource audio;

    private weaponManager weaponMan;

    private GameObject assaultPlayer;
    private GameObject huntingRiflePlayer;
    private GameObject SMGPlayer;
    private GameObject shotgunPlayer;
    private GameObject player;

    private float maxAngularSpeed = 1.5f;
    private bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
       
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
     

        player = GameObject.FindGameObjectWithTag("Player");
        weaponMan = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<weaponManager>();
        SMGPlayer = GameObject.FindGameObjectWithTag("playerSGM");
        shotgunPlayer = GameObject.FindGameObjectWithTag("Shotty");
        huntingRiflePlayer = GameObject.FindGameObjectWithTag("playerHuntingRifle");
        assaultPlayer = GameObject.FindGameObjectWithTag("assaultRifle");
        audio = GetComponent<AudioSource>();
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    isTrigger = true;
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    isTrigger = false;
    //}

   
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
        {
            if (this.gameObject.tag == "Alcohol")
            {
                int alcoholNum = player.GetComponent<Crafting>().getAlcohol();
                player.GetComponent<Crafting>().setAlcohol(alcoholNum + 1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Ammo")
            {
                int currentWeapon = weaponMan.GetEquippedWeapon();

                if (currentWeapon == 1)
                {
                    SMGPlayer.GetComponent<SMGbehavior>().takeAmmo(10);
                }

                if (currentWeapon == 2)
                {
                    shotgunPlayer.GetComponent<ShotgunBehaviour>().takeAmmo(10);
                }

                if (currentWeapon == 3)
                {
                    huntingRiflePlayer.GetComponent<huntingRifleBehavior>().takeAmmo(10);
                }
                if (currentWeapon == 4)
                {
                    assaultPlayer.GetComponent<assaultBehaviour>().takeAmmo(10);
                }
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Rag")
            {
                int rags = player.GetComponent<Crafting>().getRags();
                player.GetComponent<Crafting>().setRags(rags + 1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Sugar")
            {
                int sugarNum = player.GetComponent<Crafting>().getSugar();
                player.GetComponent<Crafting>().setSugar(sugarNum + 1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Canister")
            {
                int canisterNum = player.GetComponent<Crafting>().getCanister();
                player.GetComponent<Crafting>().setCanister(canisterNum + 1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "GunPowder")
            {
                int gunPowderNum = player.GetComponent<Crafting>().getGunPowder();
                player.GetComponent<Crafting>().setGunPowder(gunPowderNum + 1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "HealthPack")
            {
                int healthPacks = player.GetComponent<Crafting>().getHealthPack();
                player.GetComponent<Crafting>().setHealthPack(healthPacks + 1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Assault")
            {
                weaponMan.collect(4);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "HuntingRifle")
            {
                weaponMan.collect(3);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Shotgun")
            {
                weaponMan.collect(2);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "SMG")
            {
                weaponMan.collect(1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "PipeBomb")
            {
                player.GetComponent<grenades>().addPipe(1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Molotov")
            {
                player.GetComponent<grenades>().addMol(1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

            if (this.gameObject.tag == "Stun")
            {
                player.GetComponent<grenades>().addStun(1);
                this.GetComponent<Animator>().SetTrigger("collect");
                audio.Play();
                Destroy(this.gameObject, 2f);
            }

        }

    }
}
