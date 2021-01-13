using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public static AudioMixerController Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
            return;
        }
    }

    public float GetMaster() {
        float value;
        mixer.GetFloat("Master", out value);
        return value;
    }

    public void SetMaster(float value) {
        mixer.SetFloat("Master", value);
    }

    public float GetAmbiance() {
        float value;
        mixer.GetFloat("Ambiance", out value);
        return value;
    }

    public void SetAmbiance(float value) {
        mixer.SetFloat("Ambiance", value);
    }

    public float GetVFX() {
        float value;
        mixer.GetFloat("VFX", out value);
        return value;
    }

    public void SetVFX(float value) {
        mixer.SetFloat("VFX", value);
    }

    public float GetVoiceOver() {
        float value;
        mixer.GetFloat("VoiceOver", out value);
        return value;
    }

    public void SetVoiceOver(float value) {
        mixer.SetFloat("VoiceOver", value);
    }

    public float GetMonsters() {
        float value;
        mixer.GetFloat("Monsters", out value);
        return value;
    }

    public void SetMonsters(float value){
        mixer.SetFloat("Monsters", value);
    }

    public float GetSoundtrack() {
        float value;
        mixer.GetFloat("Soundtrack", out value);
        return value;
    }

    public void SetSoundtrack(float value) {
        mixer.SetFloat("Soundtrack", value);
    }
}
