using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackButton : MonoBehaviour
{
    private GameObject allyManager;

   public void Back()
    {
        allyManager = GameObject.FindGameObjectWithTag("AllyManager");
        Destroy(allyManager.gameObject);
        SceneManager.LoadScene("Start_Menu");
    }
}
