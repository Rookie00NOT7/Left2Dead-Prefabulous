using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageAllWithin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "target": other.gameObject.GetComponent<ZombieController>().takeDamage(10); break;
            case "spitter": other.gameObject.GetComponent<spitterController>().takeDamage(10); break;
            case "Tank": other.gameObject.GetComponent<TankController>().takeDamage(10); break;
            case "charger": other.gameObject.GetComponent<ChargerControlScript>().takeDamage(10); break;
            case "boomer": other.gameObject.GetComponent<boomerController>().takeDamage(10); break;
            default: break;
        }
    }
}
