using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePuddle : MonoBehaviour
{
    public GameObject Puddle;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "spitter")
        {
            Instantiate(Puddle, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z),  Quaternion.Euler(-90, 0, 0));
            Destroy(this.gameObject);
        }
    }
}