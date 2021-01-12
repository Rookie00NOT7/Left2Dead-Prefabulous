using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class levelManager : MonoBehaviour
{
    private GameObject player;
    private GameObject ally;
    private int level = 0;
    private bool[] weapons;
    private WaitForSeconds tele = new WaitForSeconds(0.05f);
    private weaponManager weaponManager;
    private bool[] w;

    public static levelManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void nextLevel(int nextLevel)
    {
        level = nextLevel;
    }

    public void setWeapons(bool[] w)
    {
        weapons = w;
    }

    public void instantiateGame()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager").GetComponent<weaponManager>();
        w = weaponManager.getWeapons();
        SceneManager.LoadScene("Scene_A");
        StartCoroutine(teleport());
    }

    private IEnumerator teleport()
    {
        yield return tele;
        weaponManager = GameObject.FindWithTag("WeaponManager").GetComponent<weaponManager>();
        weaponManager.setWeapons(w);
        if (level != 0)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<CharacterController>().enabled = false;
            ally = GameObject.FindGameObjectWithTag("Ellie");
            ally.GetComponent<NavMeshAgent>().enabled = false;
            if (ally == null)
            {
                ally = GameObject.FindGameObjectWithTag("Louis");
            }
            switch (level)
            {
                case 1:
                    player.transform.position = GameObject.FindGameObjectWithTag("teleport1").transform.position;
                    ally.transform.position = GameObject.FindGameObjectWithTag("teleportAlly1").transform.position;
                    ally.GetComponent<NavMeshAgent>().enabled = true;
                    break;
                case 2:
                    player.transform.position = GameObject.FindGameObjectWithTag("teleport2").transform.position;
                    ally.transform.position = GameObject.FindGameObjectWithTag("teleportAlly3").transform.position;
                    ally.GetComponent<NavMeshAgent>().enabled = true;
                    break;
                case 3:
                    player.transform.position = GameObject.FindGameObjectWithTag("teleport3").transform.position;
                    ally.transform.position = GameObject.FindGameObjectWithTag("teleportAlly3").transform.position;
                    ally.GetComponent<NavMeshAgent>().enabled = true;
                    break;
            }
        }
    }
}
