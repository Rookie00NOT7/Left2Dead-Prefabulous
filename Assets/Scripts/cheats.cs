using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheats : MonoBehaviour
{
    private weaponManager wm;
    private int i = 0;

    public GameObject[] enemies;
    public GameObject levelDest1;
    public GameObject levelDest2;
    public GameObject levelDest3;
    public GameObject levelDest4;

    public GameObject levelDam1;
    public GameObject levelDam2;
    public GameObject levelDam3;
    public GameObject levelDam4;

    void Start()
    {
        wm = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<weaponManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            i = (i + 1) % enemies.Length;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.gameObject.GetComponent<PlayerAddedBehavior>().heal(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wm.fillAll();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject z = Instantiate(enemies[i], this.gameObject.transform.position + new Vector3(this.gameObject.transform.forward.x, this.gameObject.transform.forward.y, 5*this.gameObject.transform.forward.z), Quaternion.identity);
            switch (i)
            {
                case 0: z.GetComponent<ZombieController>().setSeen();break;
                case 1: z.GetComponent<spitterController>().setSeen();break;
                case 2: z.GetComponent<TankController>().setSeen();break;
                case 3: z.GetComponent<ChargerControlScript>().setSeen();break;
                case 4: z.GetComponent<boomerController>().setSeen();break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            for(int j=0; j<20; j++)
            {
                GameObject z = Instantiate(enemies[0], this.gameObject.transform.position + new Vector3(this.gameObject.transform.forward.x, this.gameObject.transform.forward.y, 10 * this.gameObject.transform.forward.z), Quaternion.identity);
                z.GetComponent<ZombieController>().setSeen();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            int level = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<levelManager>().getLevel();
            switch (level)
            {
                case 0: levelDest1.SetActive(true);break;
                case 1: levelDest2.SetActive(true); break;
                case 2: levelDest3.SetActive(true); break;
                case 3: levelDest4.SetActive(true); break;
                default: break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            int level = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<levelManager>().getLevel();
            switch (level)
            {
                case 0: levelDam1.SetActive(true); break;
                case 1: levelDam2.SetActive(true); break;
                case 2: levelDam3.SetActive(true); break;
                case 3: levelDam4.SetActive(true); break;
                default: break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            this.gameObject.GetComponent<grenades>().addMol(3);
            this.gameObject.GetComponent<grenades>().addPipe(2);
            this.gameObject.GetComponent<grenades>().addStun(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            this.gameObject.GetComponent<PlayerAddedBehavior>().rage("target");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            this.gameObject.GetComponent<PlayerAddedBehavior>().setRage();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            levelManager lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<levelManager>();
            if(lm.getLevel() + 1 < 4)
            {
                lm.nextLevel(lm.getLevel() + 1);
                lm.instantiateGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject ally = GameObject.FindGameObjectWithTag("Ellie");
            if (ally == null)
            {
                ally = GameObject.FindGameObjectWithTag("Louis");
                ally.GetComponent<louisBehaviour>().addAmmo();
            }
            else
            {
                ally.GetComponent<EllieBehavior>().addAmmo();
            }
            
        }
    }
}
