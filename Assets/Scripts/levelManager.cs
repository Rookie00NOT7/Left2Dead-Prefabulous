using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class levelManager : MonoBehaviour
{
    private GameObject player;
    private GameObject ally;
    private GameObject Ellie;
    private GameObject Louis;
    private static int level = 0;
    private bool[] weapons;
    private WaitForSeconds tele = new WaitForSeconds(0.05f);
    private weaponManager weaponManager;
    private bool[] w;
    private bool is_ellie;
    private Vector3 allyPosition;


    public static levelManager Instance;

    public static string ObjectiveText() {
        switch(level) {
            case 0:
                return "Go through the house";
                break;
            case 1:
                return "Go through the mansion's garden";
                break;
            case 2:
                return "Go through the street";
                break;
            default:
                return "Clear out the chapel and procced through the gate before the timer runs out!";
                break;
        }
    }

    public int getLevel()
    {
        return level;
    }

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
        Debug.Log("LEVEEEL: " + level);
        level = nextLevel;
        level = Mathf.Clamp(level, 0, 3);
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
        is_ellie = GameObject.FindWithTag("AllyManager").GetComponent<AllyManager>().GetIsEllie();
        allyPosition = GameObject.FindWithTag("AllyInitialPos").transform.position;
        Ellie = GameObject.FindWithTag("AllyManager").GetComponent<AllyManager>().Ellie;
        Louis = GameObject.FindWithTag("AllyManager").GetComponent<AllyManager>().Louis;

        if (is_ellie)
        {
            Instantiate(Ellie, allyPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(Louis, allyPosition, Quaternion.identity);
        }
        weaponManager.setWeapons(w);

        if (level != 0)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<CharacterController>().enabled = false;
           
            if (is_ellie)
            {
                ally = GameObject.FindGameObjectWithTag("Ellie");
            }
            else
            {
                ally = GameObject.FindGameObjectWithTag("Louis");
            }

            ally.GetComponent<NavMeshAgent>().enabled = false;

            switch (level)
            {
                case 1:
                    player.transform.position = GameObject.FindGameObjectWithTag("teleport1").transform.position;
                    player.GetComponent<CharacterController>().enabled = true;
                    ally.transform.position = GameObject.FindGameObjectWithTag("teleportAlly1").transform.position;
                    ally.GetComponent<NavMeshAgent>().enabled = true;
                    break;
                case 2:
                    player.transform.position = GameObject.FindGameObjectWithTag("teleport2").transform.position;
                    player.GetComponent<CharacterController>().enabled = true;
                    ally.transform.position = GameObject.FindGameObjectWithTag("teleportAlly2").transform.position;
                    ally.GetComponent<NavMeshAgent>().enabled = true;
                    break;
                case 3:
                    player.transform.position = GameObject.FindGameObjectWithTag("teleport3").transform.position;
                    player.GetComponent<CharacterController>().enabled = true;
                    ally.transform.position = GameObject.FindGameObjectWithTag("teleportAlly3").transform.position;
                    ally.GetComponent<NavMeshAgent>().enabled = true;
                    break;
            }
        }
    }
}
