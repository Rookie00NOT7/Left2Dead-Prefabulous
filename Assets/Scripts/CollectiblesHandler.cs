using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesHandler : MonoBehaviour
{
    private GameObject ammo;
    private GameObject sugar;
    private GameObject healthPack;
    private GameObject alcohol;
    private GameObject canister;
    private GameObject gunPowder;
    private GameObject rag;
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
    public AudioClip ragSound;
    public AudioClip gunPowderSound;
    public AudioClip ammoSound;
    public AudioClip sugarSound;
    public AudioClip canisterSound;
    public AudioClip healthPackSound;
    public AudioClip alcoholSound;

    private GameObject assaultPlayer;
    private GameObject huntingRiflePlayer;
    private GameObject SMGPlayer;
    private GameObject shotgunPlayer;

    private float maxAngularSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GameObject.FindGameObjectWithTag("Ammo");
        alcohol = GameObject.FindGameObjectWithTag("Alcohol");
        rag = GameObject.FindGameObjectWithTag("Rag");
        sugar = GameObject.FindGameObjectWithTag("Sugar");
        canister = GameObject.FindGameObjectWithTag("Canister");
        gunPowder = GameObject.FindGameObjectWithTag("GunPowder");
        healthPack = GameObject.FindGameObjectWithTag("HealthPack");
        assault = GameObject.FindGameObjectWithTag("Assault");
        huntingRifle = GameObject.FindGameObjectWithTag("HuntingRifle");
        shotgun = GameObject.FindGameObjectWithTag("Shotgun");
        SMG = GameObject.FindGameObjectWithTag("SMG");
        pipeBomb = GameObject.FindGameObjectWithTag("PipeBomb");
        molotov = GameObject.FindGameObjectWithTag("Molotov");
        stunGrenade = GameObject.FindGameObjectWithTag("Stun");
        weaponMan = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<weaponManager>();
        SMGPlayer = GameObject.FindGameObjectWithTag("playerSGM");
        shotgunPlayer = GameObject.FindGameObjectWithTag("Shotty");
        huntingRiflePlayer = GameObject.FindGameObjectWithTag("playerHuntingRifle");
        assaultPlayer = GameObject.FindGameObjectWithTag("assaultRifle");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rag != null)
        {
            rag.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
            if (Vector3.Distance(rag.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                int rags = GetComponent<Crafting>().getRags();
                GetComponent<Crafting>().setRags(rags + 1);
                rag.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(ragSound);
                Destroy(rag.gameObject, 2f);
            }
        }
        if (alcohol != null)
        {
            alcohol.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
            if (Vector3.Distance(alcohol.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                int alcoholNum = GetComponent<Crafting>().getAlcohol();
                GetComponent<Crafting>().setAlcohol(alcoholNum + 1);
                alcohol.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(alcoholSound);
                Destroy(alcohol.gameObject, 2f);
            }
        }
        if (ammo != null)
        {
            ammo.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
            if (Vector3.Distance(ammo.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
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
                ammo.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(ammoSound);
                Destroy(ammo.gameObject, 2f);
            }
        }
        if (healthPack != null)
        {
            healthPack.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
            if (Vector3.Distance(healthPack.transform.position, transform.position) < 10f && Input.GetKeyDown(KeyCode.E))
            {
                int healthPacks = GetComponent<Crafting>().getHealthPack();
                GetComponent<Crafting>().setHealthPack(healthPacks + 1);
                healthPack.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(healthPackSound);
                Destroy(healthPack.gameObject, 2f);
            }
        }
        if (sugar != null)
        {
            sugar.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
            if (Vector3.Distance(sugar.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                int sugarNum = GetComponent<Crafting>().getSugar();
                GetComponent<Crafting>().setSugar(sugarNum + 1);
                sugar.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(sugarSound);
                Destroy(sugar.gameObject, 2f);
            }
        }

        if (canister != null)
        {
            canister.GetComponent<Rigidbody>().angularVelocity = new Vector3(maxAngularSpeed, 0, 0);
            if (Vector3.Distance(canister.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                int canisterNum = GetComponent<Crafting>().getCanister();
                GetComponent<Crafting>().setCanister(canisterNum + 1);
                canister.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(canisterSound);
                Destroy(canister.gameObject, 2f);
            }
        }

        if (gunPowder != null)
        {
            gunPowder.GetComponent<Rigidbody>().angularVelocity = new Vector3(maxAngularSpeed, 0, 0);
            if (Vector3.Distance(gunPowder.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                int gunPowderNum = GetComponent<Crafting>().getGunPowder();
                GetComponent<Crafting>().setGunPowder(gunPowderNum + 1);
                gunPowder.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunPowderSound);
                Destroy(gunPowder.gameObject, 2f);
            }
        }
        if (assault != null)
        {
            assault.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, maxAngularSpeed);
            if (Vector3.Distance(assault.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                weaponMan.collect(4);
                assault.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(assault.gameObject, 2f);
            }
        }
        if (huntingRifle != null)
        {
            huntingRifle.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, maxAngularSpeed);
            if (Vector3.Distance(huntingRifle.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                weaponMan.collect(3);
                huntingRifle.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(huntingRifle.gameObject, 2f);
            }
        }
        if (shotgun != null)
        {
            shotgun.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, maxAngularSpeed);
            if (Vector3.Distance(shotgun.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                weaponMan.collect(2);
                shotgun.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(shotgun.gameObject, 2f);
            }
        }
        if (SMG != null)
        {
            SMG.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
            if (Vector3.Distance(SMG.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                weaponMan.collect(1);
                SMG.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(gunsSound);
                Destroy(SMG.gameObject, 2f);
            }
        }
        if (pipeBomb != null)
        {
            pipeBomb.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, maxAngularSpeed, 0);
            if (Vector3.Distance(pipeBomb.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<grenades>().addPipe(1);
                pipeBomb.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(grenadesSound);
                Destroy(pipeBomb.gameObject, 2f);
            }
        }
        if (molotov != null)
        {
            molotov.GetComponent<Rigidbody>().angularVelocity = new Vector3(maxAngularSpeed, 0, 0);
            if (Vector3.Distance(molotov.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<grenades>().addMol(1);
                molotov.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(grenadesSound);
                Destroy(molotov.gameObject, 2f);
            }
        }
        if (stunGrenade != null)
        {
            stunGrenade.GetComponent<Rigidbody>().angularVelocity = new Vector3(maxAngularSpeed, 0, 0);
            if (Vector3.Distance(stunGrenade.transform.position, transform.position) < 6f && Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<grenades>().addStun(1);
                stunGrenade.GetComponent<Animator>().SetTrigger("collect");
                audio.PlayOneShot(grenadesSound);
                Destroy(stunGrenade.gameObject, 2f);
            }
        }

    }
}
