using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeBombBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;
    private float thrust = 15.0f;
    private float time = 4f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rb.AddForce(cam.transform.forward * thrust, ForceMode.Impulse);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0f)
        {
            //instantiate explosion
            Destroy(this.gameObject);
        }
    }
}
