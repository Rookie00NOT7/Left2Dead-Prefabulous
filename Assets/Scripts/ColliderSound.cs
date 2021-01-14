using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSound : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameObject.FindWithTag("SoundtrackManager").GetComponent<SoundtrackManager>().PlayCalmTrack();
        }
    }
}
