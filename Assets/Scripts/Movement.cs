using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 500f;
    private GameObject cam;
    private Quaternion rotation;
    public float maxUp = 40f;
    public float minDown = -60f;
    // will be needed if we revert to jumping with forces, right now animations handel jumping
    private bool isGrounded;
    private Rigidbody rb;
    private float jumpForce = 1.0f;
    private Vector3 jump;
    private bool cursorShow = false;
    void Start()
    {
        Cursor.visible = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rotation = cam.transform.localRotation;
        // will be needed if we revert to jumping with forces
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // will be needed if we revert to jumping with forces
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGrounded = true;
    }

    void Update()
    {
        rotation.x -= Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
        rotation.x = Mathf.Clamp(rotation.x, minDown, maxUp);
        cam.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 4f : 2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 4f : 2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 4f : 2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 4f : 2f);
        }
        // will be needed if we revert to jumping with forces
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.transform.tag == "target")
                {
                    //Code for damage
                    Debug.Log("HIT!!");
                }
                Debug.Log(hit.transform.tag);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorShow = !cursorShow;
            Cursor.visible = cursorShow;
        }
    }
}