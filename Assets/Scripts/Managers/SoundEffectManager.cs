using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource narrationAudioSource; 

    public static SoundEffectManager S; 

    void Awake()
    {
        if (S != null && S != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void playSound(AudioClip clip)
    {
        if (!clip) return; 
        audioSource.PlayOneShot(clip); 
    }

    public void playNarration(AudioClip clip)
    {
        if (!clip) return;
        narrationAudioSource.PlayOneShot(clip); 
    }
}
