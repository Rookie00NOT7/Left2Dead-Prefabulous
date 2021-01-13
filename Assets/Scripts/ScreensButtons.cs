using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreensButtons : MonoBehaviour
{
    public RawImage PauseMenu;
    //public RawImage MainMenu;
    public RawImage GameOver;
    private GameObject levelManager;
    private GameObject player;
    private GameObject weaponManager;
    private GameObject pistol;
    private GameObject smg;
    private GameObject shotgun;
    private GameObject huntingRifle;
    private GameObject assaultRifle;
    private bool pause;

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
    }
    // Update is called once per frame
    void Update()
    {
        //mute all other sounds
        //pause and unpause using keyboard keys
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            Pause();
            
        }
       
    }

    public void Game_Over()
    {
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().getMouseLook().setCursor();
        Time.timeScale = 0f;
        GameOver.gameObject.SetActive(true);
        activateDeactiveWeapon(false);
    }

    public void Pause()
    {
        if(pause)
        {
            Time.timeScale = 0f;
            PauseMenu.gameObject.SetActive(true);
            activateDeactiveWeapon(false);
        }
        else
        {
            Time.timeScale = 1f;
            PauseMenu.gameObject.SetActive(false);
            activateDeactiveWeapon(true);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
        levelManager.GetComponent<levelManager>().instantiateGame();
        activateDeactiveWeapon(true);
        
    }

    public void Resume()
    {
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().getMouseLook().setCursor();
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
        activateDeactiveWeapon(true);
        pause = !pause;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 0f;
        PauseMenu.gameObject.SetActive(false);
        activateDeactiveWeapon(false);
        Destroy(levelManager);
        //MainMenu.gameObject.SetActive(True);
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

