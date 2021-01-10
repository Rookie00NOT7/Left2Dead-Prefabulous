using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAllWithin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "target" || other.tag == "spitter" || other.tag == "charger" || other.tag == "Tank" || other.tag == "boomer")
        {
            Destroy(other.gameObject);
        }
    }
}
