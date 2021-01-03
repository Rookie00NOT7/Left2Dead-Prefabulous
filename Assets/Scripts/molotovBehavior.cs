using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molotovBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;
    private float thrust = 15.0f;
    public GameObject Fire;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rb.AddForce(cam.transform.forward * thrust, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(Fire, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.Euler(-90, 0, 0));
            Destroy(this.gameObject);
        }
    }
}
