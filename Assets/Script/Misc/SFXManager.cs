using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    private AudioSource audioSource;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int index)
    {
        if (index >= 0 && index < audioClips.Count)
        { 
            audioSource.PlayOneShot(audioClips[index]);
        }
    }
}

