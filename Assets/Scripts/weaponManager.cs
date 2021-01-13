using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    private bool[] weapons = { true, false, false, false, false };
    private int current = 0;
    private GameObject pistol;
    private GameObject SGM;
    private GameObject shotgun;
    private GameObject huntingRifle;
    private GameObject assaultRifle;
    private WaitForSeconds hideWeapons = new WaitForSeconds(0.025f);

    public void fillAll()
    {
        SGM.GetComponent<SMGbehavior>().takeAmmo(1000);
        shotgun.GetComponent<ShotgunBehaviour>().takeAmmo(1000);
        huntingRifle.GetComponent<huntingRifleBehavior>().takeAmmo(1000);
        assaultRifle.GetComponent<assaultBehaviour>().takeAmmo(1000);
    }

    public void collect(int weapon)
    {
        weapons[weapon] = true;
    }

    public int GetEquippedWeapon()
    {
        return current;
    }

    public bool[] getWeapons()
    {
        return weapons;
    }

    public void setWeapons(bool[] curWeapons)
    {
        weapons = curWeapons;
    }

    void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("playerGun");
        SGM = GameObject.FindGameObjectWithTag("playerSGM");
        shotgun = GameObject.FindGameObjectWithTag("Shotty");
        huntingRifle = GameObject.FindGameObjectWithTag("playerHuntingRifle");
        assaultRifle = GameObject.FindGameObjectWithTag("assaultRifle");

        StartCoroutine(HideWeapons());
    }

    private IEnumerator HideWeapons()
    {
        yield return hideWeapons;
        SGM.SetActive(false);
        shotgun.SetActive(false);
        huntingRifle.SetActive(false);
        assaultRifle.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            current = (current + 1) % 5;
            while (!weapons[current])
            {
                current = (current + 1) % 5;
            }
            print(current);
            switch (current)
            {
                case 0: pistol.SetActive(true); SGM.SetActive(false); shotgun.SetActive(false); huntingRifle.SetActive(false); assaultRifle.SetActive(false); break;
                case 1: pistol.SetActive(false); SGM.SetActive(true); shotgun.SetActive(false); huntingRifle.SetActive(false); assaultRifle.SetActive(false); break;
                case 2: pistol.SetActive(false); SGM.SetActive(false); shotgun.SetActive(true); huntingRifle.SetActive(false); assaultRifle.SetActive(false); break;
                case 3: pistol.SetActive(false); SGM.SetActive(false); shotgun.SetActive(false); huntingRifle.SetActive(true); assaultRifle.SetActive(false); break;
                case 4: pistol.SetActive(false); SGM.SetActive(false); shotgun.SetActive(false); huntingRifle.SetActive(false); assaultRifle.SetActive(true); break;
                    //the rest
            }
        }
    }
}
