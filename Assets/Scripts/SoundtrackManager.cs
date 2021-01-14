using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundtrackManager : MonoBehaviour
{
   public AudioClip calmTrack;
   public AudioClip upbeatTrack;
   public AudioClip upbeatTrack2;
   public static SoundtrackManager Instance;
   public int currentTrack = 0;
   private int currentLevel = 0;

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
        if(SceneManager.GetActiveScene().name != "Scene_A") //scene_A index
        {
            if(currentTrack == 0 || currentTrack == 2 || currentTrack == 3) //no active tracks 
            {
                PlayCalmTrack();
                currentTrack = 1;
            }
        }
        else
        {
            currentLevel = GameObject.FindWithTag("LevelManager").GetComponent<levelManager>().getLevel();
            if (currentLevel == 0 || currentLevel == 1)
            {
                if (currentTrack == 0 || currentTrack == 1 || currentTrack == 3)
                {
                    PlayUpbeatTrack();
                    currentTrack = 2;
                } 
            }
            
            if(currentLevel == 2 || currentLevel == 3)
            {
                if (currentTrack == 0 || currentTrack == 1 || currentTrack == 2)
                {
                    PlayUpBeatTrack2();
                    currentTrack = 3;
                }
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
   
   public void PlayUpBeatTrack2()
   {
        audioSource.clip = upbeatTrack2;
        audioSource.Play();
    }

   public void PauseTrack() {
       audioSource.Pause();
   }

   public void StopTrack() {
       audioSource.Stop();
   }
}
