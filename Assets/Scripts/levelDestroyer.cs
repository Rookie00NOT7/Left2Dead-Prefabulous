using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelDestroyer : MonoBehaviour
{
    public GameObject levelDest;
    public GameObject closed1;
    public GameObject closed2;
    public GameObject opened1;
    public GameObject opened2;
    private levelManager levMan;

    void Start()
    {
        levMan = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<levelManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelDest.SetActive(true);
            closed1.SetActive(true);
            closed2.SetActive(true);
            opened1.SetActive(false);
            opened2.SetActive(false);
            switch (this.gameObject.name)
            {
                case "level1 end": levMan.nextLevel(1);break;
                case "level2 end": levMan.nextLevel(2); break;
                case "level3 end": levMan.nextLevel(3); break;
                case "level4 end": levMan.nextLevel(4); break;
            }
            //next objective card UI
        }
    }
}
