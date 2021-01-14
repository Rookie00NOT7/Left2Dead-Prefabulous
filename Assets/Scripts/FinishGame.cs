using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private WaitForSeconds tele = new WaitForSeconds(2f);
   private void OnTriggerEnter(Collider other) {
       if (other.transform.tag == "Player") {
            StartCoroutine(loader());
       }
   } 

   private IEnumerator loader(){
        yield return tele;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Credits");

    }
}
