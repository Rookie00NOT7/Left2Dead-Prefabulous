using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCountdown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("timer").GetComponent<countdown>().stopCounting();
        }
    }
}
