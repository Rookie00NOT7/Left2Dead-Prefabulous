using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    private WaitForSeconds tele = new WaitForSeconds(8f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loader());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            SceneManager.LoadScene("Start_Menu");
        }
    }

    private IEnumerator loader(){
        yield return tele;
        SceneManager.LoadScene("Start_Menu");

    }
}
