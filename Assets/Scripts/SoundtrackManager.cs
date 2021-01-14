using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundtrackManager : MonoBehaviour
{
   public AudioClip calmTrack;
   public AudioClip upbeatTrack;
   public static SoundtrackManager Instance;
   private int currentTrack = 0;

   private AudioSource audioSource;

   private void Awake() {
       if (Instance == null) {
           Instance = this;
           DontDestroyOnLoad(this.gameObject);
       } else {
           Destroy(this.gameObject);
           return;
       }
   }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            if(currentTrack == 0 || currentTrack == 2) //no active tracks 
            {
                PlayCalmTrack();
                currentTrack = 1;
            }
        }
        else
        {
            if(currentTrack == 0 || currentTrack == 1)
            {
                PlayUpbeatTrack();
                currentTrack = 2;
            }
        }
    }

    private void Start() {
       audioSource = gameObject.GetComponent<AudioSource>();
   }

   public void PlayCalmTrack() {
       audioSource.clip = calmTrack;
       audioSource.Play();
   }

   public void PlayUpbeatTrack() {
       audioSource.clip = upbeatTrack;
       audioSource.Play();
   }

   public void PauseTrack() {
       audioSource.Pause();
   }

   public void StopTrack() {
       audioSource.Stop();
   }
}
