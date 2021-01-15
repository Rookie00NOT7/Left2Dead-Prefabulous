using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreensButtons : MonoBehaviour
{
    public RawImage PauseMenu;
    public RawImage GameOver;
    private GameObject levelManager;
    private GameObject player;
    private GameObject weaponManager;
    private GameObject pistol;
    private GameObject smg;
    private GameObject shotgun;
    private GameObject huntingRifle;
    private GameObject assaultRifle;
    private GameObject audioMixer;
    private GameObject allyManager;
    private bool pause;
    private bool crafting_on = false;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        player = GameObject.FindGameObjectWithTag("Player");
        weaponManager = GameObject.FindGameObjectWithTag("WeaponManager");
        pistol = GameObject.FindGameObjectWithTag("playerGun");
        smg = GameObject.FindGameObjectWithTag("playerSGM");
        shotgun = GameObject.FindGameObjectWithTag("Shotty");
        huntingRifle = GameObject.FindGameObjectWithTag("playerHuntingRifle");
        assaultRifle = GameObject.FindGameObjectWithTag("assaultRifle");
        audioMixer = GameObject.FindGameObjectWithTag("AudioMixerController");
    }

    //public void set_crafting()
    //{
    //    crafting_on = false;
    //}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            crafting_on = !crafting_on;
        }

        //mute all other sounds
        //pause and unpause using keyboard keys
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (crafting_on == false)
            {
                pause = !pause;
                Pause();
            }
               
        }
       
    }

    public void Game_Over()
    {
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().getMouseLook().setCursor();
        audioMixer.GetComponent<AudioMixerController>().SetMaster(-80.0f);
        Time.timeScale = 0f;
        GameOver.gameObject.SetActive(true);
        activateDeactiveWeapon(false);
    }

    public void Pause()
    {
        if(pause)
        {
            audioMixer.GetComponent<AudioMixerController>().SetMaster(-80.0f);
            Time.timeScale = 0f;
            PauseMenu.gameObject.SetActive(true);
            activateDeactiveWeapon(false);
        }
        else
        {
            Time.timeScale = 1f;
            PauseMenu.gameObject.SetActive(false);
            activateDeactiveWeapon(true);
            audioMixer.GetComponent<AudioMixerController>().SetMaster(0);
        }
    }

    public void RestartLevel()
    {
        audioMixer.GetComponent<AudioMixerController>().SetMaster(0);
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
        levelManager.GetComponent<levelManager>().instantiateGame();
        activateDeactiveWeapon(true);
        
    }

    public void Resume()
    {
        audioMixer.GetComponent<AudioMixerController>().SetMaster(0.0f);
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().getMouseLook().setCursor();
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
        activateDeactiveWeapon(true);
        pause = !pause;
    }

    public void QuitToMainMenu()
    {
        allyManager = GameObject.FindGameObjectWithTag("AllyManager");
        Time.timeScale = 0f;
        PauseMenu.gameObject.SetActive(false);
        activateDeactiveWeapon(false);
        levelManager.GetComponent<levelManager>().nextLevel(0);
        Destroy(levelManager);
        Destroy(allyManager);
        SceneManager.LoadScene("Start_Menu");
        Time.timeScale = 1f;
        audioMixer.GetComponent<AudioMixerController>().SetMaster(0f);
    }

    public void activateDeactiveWeapon(bool flag)
    {
        int weapon = weaponManager.GetComponent<weaponManager>().GetEquippedWeapon();
        if (flag==true)
        {
            switch (weapon)
            {
                case 0: pistol.SetActive(true); break;
                case 1: smg.SetActive(true); break;
                case 2: shotgun.SetActive(true); break;
                case 3: huntingRifle.SetActive(true); break;
                case 4: assaultRifle.SetActive(true); break;
            }
        }
        else
        {
            switch (weapon)
            {
                case 0: pistol.SetActive(false); break;
                case 1: smg.SetActive(false); break;
                case 2: shotgun.SetActive(false); break;
                case 3: huntingRifle.SetActive(false); break;
                case 4: assaultRifle.SetActive(false); break;
            }
        }
    }

}

