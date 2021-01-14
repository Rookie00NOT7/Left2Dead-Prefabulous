using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
       if (other.transform.tag == "Player") {
           // Scene manager transition to next scene
       }
   } 
}
