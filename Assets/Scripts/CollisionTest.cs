using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
   private AudioSource audio;
   public  AudioClip test;

   private void OnTriggerStay(Collider other) {
       if (other.transform.tag == "Level1Enter") {
           audio.PlayOneShot(test);
       } else {
           Debug.Log(other.transform.tag);
       }
   }
}
