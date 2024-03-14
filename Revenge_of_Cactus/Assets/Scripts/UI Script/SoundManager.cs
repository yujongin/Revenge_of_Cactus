using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipClick;
    public AudioClip audioClipApplause;

    public static SoundManager instance;


    void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }  
    }
    
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(audioClipClick);
    }

    public void PlayApplauseSound()
    {
        audioSource.PlayOneShot(audioClipApplause);
    }

}
