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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelDest.SetActive(true);
            closed1.SetActive(true);
            closed2.SetActive(true);
            opened1.SetActive(false);
            opened2.SetActive(false);
            //next objective card UI
        }
    }
}
