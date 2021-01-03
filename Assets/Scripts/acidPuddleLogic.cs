using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidPuddleLogic : MonoBehaviour
{
    private float timeToLive = 5.0f;
    private float nextHit = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerAddedBehavior player = other.gameObject.GetComponent<PlayerAddedBehavior>();
            if (nextHit <= 0f)
            {
                player.takeDamage(20);
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
