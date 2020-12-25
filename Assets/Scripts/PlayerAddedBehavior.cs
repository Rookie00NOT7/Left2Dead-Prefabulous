using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddedBehavior : MonoBehaviour
{
    private CharacterController controller;
    private int health = 300;

    public Vector3 moveDirection;

    public const float maxDashTime = 1.0f;
    public float dashDistance = 10;
    public float dashStoppingSpeed = 0.1f;
    float currentDashTime = maxDashTime;
    float dashSpeed = 5;
    private bool forwardDash = false;
    private bool backwardDash = false;
    private bool rightDash = false;
    private bool leftDash = false;
    private Animator hitPanel;
    private AudioSource audio;
    public AudioClip hitClip;
    private bool playOrNot = true; 

    public void takeDamage(int val)
    {
        health -= val;
        if (health <= 0)
        {
            hitPanel.SetTrigger("die");
            //add UI for game over screen and so on ...
        }
        else
        {
            hitPanel.SetTrigger("hit");
            if(playOrNot)
                audio.PlayOneShot(hitClip);
            playOrNot = !playOrNot;
        }
    }
    void Start()
    {
        hitPanel = GameObject.FindGameObjectWithTag("hitPanel").GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.W))
            {
                currentDashTime = 0;
                forwardDash = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                currentDashTime = 0;
                backwardDash = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                currentDashTime = 0;
                rightDash = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                currentDashTime = 0;
                leftDash = true;
            }

        }

        if (currentDashTime < maxDashTime)
        {
            if (forwardDash)
            {
                moveDirection = transform.forward * dashDistance;
                currentDashTime += dashStoppingSpeed;
            }
            else
            {
                if (backwardDash)
                {
                    moveDirection = -transform.forward * dashDistance;
                    currentDashTime += dashStoppingSpeed;
                }
                else
                {
                    if (rightDash)
                    {
                        moveDirection = transform.right * dashDistance;
                        currentDashTime += dashStoppingSpeed;
                    }
                    else
                    {
                        if (leftDash)
                        {
                            moveDirection = -transform.right * dashDistance;
                            currentDashTime += dashStoppingSpeed;
                        }
                    }
                }
            }
        }
        else
        {
            moveDirection = Vector3.zero;
            forwardDash = false;
            backwardDash = false;
            rightDash = false;
            leftDash = false;
        }
        if (forwardDash || backwardDash || rightDash || leftDash)
        {
            controller.Move(moveDirection * Time.deltaTime * dashSpeed);
        }
    }
}

