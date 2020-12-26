using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target" || other.tag == "specialTarget")
        {
            ZombieController zombie = other.gameObject.GetComponent<ZombieController>();
            zombie.takeDamage(100);
        }
    }
}