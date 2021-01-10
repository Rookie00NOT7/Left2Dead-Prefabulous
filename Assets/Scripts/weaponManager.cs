using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    private bool[] weapons = { true, true, true, true, false };
    private int current = 0;
    private GameObject pistol;
    private GameObject SGM;
    private GameObject shotgun;

    private GameObject huntingRifle;
    //    to be made
    //    private GameObject assault;

    public void collect(int weapon)
    {
        weapons[weapon] = true;
    }

    public int GetEquippedWeapon() {
        return current;
    }

    void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("playerGun");
        SGM = GameObject.FindGameObjectWithTag("playerSGM");
        shotgun = GameObject.FindGameObjectWithTag("Shotty");
        huntingRifle=GameObject.FindGameObjectWithTag("playerHuntingRifle");
        SGM.SetActive(false);
        shotgun.SetActive(false);
        huntingRifle.SetActive(false);

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
                case 0: pistol.SetActive(true); SGM.SetActive(false); shotgun.SetActive(false); huntingRifle.SetActive(false); break;
                case 1: pistol.SetActive(false); SGM.SetActive(true); shotgun.SetActive(false);  huntingRifle.SetActive(false);break;
                case 2: pistol.SetActive(false); SGM.SetActive(false); shotgun.SetActive(true);  huntingRifle.SetActive(false);break;
                case 3: pistol.SetActive(false); SGM.SetActive(false); shotgun.SetActive(false); huntingRifle.SetActive(true); break;
                    //the rest
            }
        }
    }
}
