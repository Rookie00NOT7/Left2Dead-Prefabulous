using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu_Manager : MonoBehaviour
{
    public GameObject Options_Panel;
    public GameObject Start_Panel;
    public GameObject How_to_PLay;
    public GameObject Credits_Panel;
    void Start()
    {  
        Options_Panel.SetActive(false);
        Start_Panel.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            How_to_PLay.SetActive(false);
            Credits_Panel.SetActive(false);

        }
    }
    public void startGame(){
        SceneManager.LoadScene("Scene_A");
    }
    public void Options(){
        Options_Panel.SetActive(true);
        Start_Panel.SetActive(false);

    }
    public void returntostartpanel(){
        Options_Panel.SetActive(false);
        Start_Panel.SetActive(true);

    }
    public void Exit(){
        Application.Quit();

    }
    public void Credits(){
        Credits_Panel.SetActive(true);
    }
    public void howtoplay(){
        How_to_PLay.SetActive(true);
    }
}
