using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireLogic : MonoBehaviour
{
    private float timeToLive = 5.0f;
    private float nextHit = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "target")
        {
            ZombieController target = other.gameObject.GetComponent<ZombieController>();
            if (nextHit <= 0f)
            {
                target.takeDamage(25);
                nextHit = 1f;
            }
            else
            {
                nextHit -= Time.deltaTime;
            }

        }
        if (other.tag == "spitter")
        {
            spitterController target = other.gameObject.GetComponent<spitterController>();
            if (nextHit <= 0f)
            {
                target.takeDamage(25);
                nextHit = 1f;
            }
            else
            {
                nextHit -= Time.deltaTime;
            }

        }
    }

    void Update()
    {
        if (timeToLive <= 0f)
        {
            Destroy(this.gameObject);
        }
        timeToLive -= Time.deltaTime;

    }
}
