using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    private bool[] weapons = {true, true, false, false};
    private int current = 0;
    private GameObject pistol;
    private GameObject SGM;
//    to be made
//    private GameObject shotgun;
//    private GameObject assault;

    void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("playerGun");
        SGM = GameObject.FindGameObjectWithTag("playerSGM");
        SGM.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            current = (current + 1) % 4;
            while (!weapons[current])
            {
                current = (current + 1) % 4;
            }
            print(current);
            switch (current) {
                case 0: pistol.SetActive(true); SGM.SetActive(false); break;
                case 1: pistol.SetActive(false); SGM.SetActive(true); break;
                //the rest
            }
        }
    }
}
