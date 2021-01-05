using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDamage : MonoBehaviour
{
    private PlayerAddedBehavior player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAddedBehavior>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target")
        {
            ZombieController zombie = other.gameObject.GetComponent<ZombieController>();
            bool kill = zombie.takeDamage(100);
            if (kill)
            {
                player.killPlus();
                player.rage(tag);
            }
        }
        else
        {
            if(other.tag == "spitter")
            {
                spitterController spitter = other.gameObject.GetComponent<spitterController>();
                bool kill = spitter.takeDamage(100);
                if (kill)
                {
                    player.killPlus();
                    player.rage(tag);
                }
            }
            else
            {
                if (other.tag == "charger")
                {
                    ChargerControlScript spitter = other.gameObject.GetComponent<ChargerControlScript>();
                    bool kill = spitter.takeDamage(100);
                    if (kill)
                    {
                        player.killPlus();
                        player.rage(tag);
                    }
                }
            }
        }
    }
}