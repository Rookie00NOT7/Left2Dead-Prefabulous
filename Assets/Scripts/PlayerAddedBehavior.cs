using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddedBehavior : MonoBehaviour
{
    private CharacterController controller;
    private int health = 300;
    private bool healing = false;

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
    private float rageTime = 0;
    private int rageMeter = 0;
    private bool rageOn = false;
    private float rageOnTime = 0.0f;
    private int rageMult = 1;
    private int kills = 0;
    public AudioClip rageModeClip;
    public AudioClip dieClip;
    private float healthTime = 0f;

    public void setRage()
    {
        rageOn = !rageOn;
        if (rageOnTime <= 0f)
        {
            rageOnTime = 7.0f;
        }
    }

    public int getRageMeter()
    {
        return rageMeter;
    }

    public void heal(int val)
    {
        health += val;
        health = Mathf.Clamp(health, 0, 300);
    }

    public int getHealth()
    {
        return health;
    }

    public bool killCount()
    {
        if (kills >= 10)
        {
            kills = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void killPlus()
    {
        kills++;
    }

    public bool getRageMode()
    {
        return rageOn;
    }

    public void takeDamage(int val)
    {
        health -= val;
        health = Mathf.Clamp(health, 0, 300);
        if (health <= 0)
        {
            hitPanel.SetTrigger("die");
            audio.PlayOneShot(dieClip);
            //Time.timeScale = 0;
            //add UI for game over screen and so on ...
            //replace with UI that does the following ...
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<levelManager>().instantiateGame();
        }
        else
        {
            hitPanel.SetTrigger("hit");
            if (playOrNot)
                audio.PlayOneShot(hitClip);
            playOrNot = !playOrNot;
        }
    }

    public void rage(string type)
    {
        if (!rageOn)
        {
            if (type == "target")
            {
                rageMeter += (10 * rageMult);
                rageTime = 3.0f;
            }
            else
            {
                rageMeter += (50 * rageMult);
                rageTime = 3.0f;
            }
            rageMeter = Mathf.Clamp(rageMeter, 0, 100);
        }
    }

    void Start()
    {
        hitPanel = GameObject.FindGameObjectWithTag("hitPanel").GetComponent<Animator>();
        if (GameObject.FindGameObjectWithTag("Ellie") != null)
        {
            rageMult = 2;
        }
        if (GameObject.FindGameObjectWithTag("Louis") != null)
        {
            healing = true;
        }
        controller = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Heal Logic
        if (healing)
        {
            if (healthTime <= 10f)
            {
                healthTime += Time.deltaTime;
            }

            if (health <= 300 && healthTime >= 1.0f)
            {
                print(health);
                healthTime = 0f;
                heal(1);
            }
        }
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

        if (rageTime > 0.0f)
        {
            rageTime -= Time.deltaTime;
        }
        else
        {
            rageMeter = 0;
        }

        if (Input.GetKeyDown(KeyCode.F) && rageMeter >= 100)
        {
            audio.PlayOneShot(rageModeClip);
            rageOn = true;
            rageOnTime = 7.0f;
        }

        if (rageOnTime > 0.0f)
        {
            rageOnTime -= Time.deltaTime;
        }
        else
        {
            rageOn = false;
            rageOnTime = 0.0f;
        }
    }
}

