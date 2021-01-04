using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    private bool[] weapons = { true, true, true, false, false };
    private int current = 0;
    private GameObject pistol;
    private GameObject SGM;
    private GameObject shotgun;
    //    to be made
    //    private GameObject assault;

    void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("playerGun");
        SGM = GameObject.FindGameObjectWithTag("playerSGM");
        shotgun = GameObject.FindGameObjectWithTag("Shotty");
        SGM.SetActive(false);
        shotgun.SetActive(false);
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
                case 0: pistol.SetActive(true); SGM.SetActive(false); shotgun.SetActive(false); break;
                case 1: pistol.SetActive(false); SGM.SetActive(true); shotgun.SetActive(false); break;
                case 2: pistol.SetActive(false); SGM.SetActive(false); shotgun.SetActive(true); break;
                    //the rest
            }
        }
    }
}
