using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllieCollsion : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip voiceOver;

    private void Start() {
        audio = gameObject.GetComponent<AudioSource>();
    }

   private void OnTriggerEnter(Collider other)  {
       if (other.transform.tag == "Level1Enter") {
           audio.PlayOneShot(voiceOver);
       }
   }
}
