using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
   public AudioClip calmTrack;
   public AudioClip upbeatTrack;

   private AudioSource audioSource;

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
