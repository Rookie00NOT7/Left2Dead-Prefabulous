using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown : MonoBehaviour
{
    private float timeRemaining = 3f * 60f;
    private bool counting = false;

    private Animator hitPanel;
    private AudioSource audio;
    public AudioClip dieClip;

    private void Start() {
        hitPanel = GameObject.FindGameObjectWithTag("hitPanel").GetComponent<Animator>();
        audio = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            counting = true;
        }
    }
    public void stopCounting()
    {
        counting = false;
    }
    void Update()
    {
        if (counting)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            Debug.Log(minutes + ":" + seconds);
            // reaching min = 0 and sec = 0 ----> game over
            GameObject.FindWithTag("Player").GetComponent<PlayerAddedBehavior>().takeDamage(1000);
        }
    }
}
