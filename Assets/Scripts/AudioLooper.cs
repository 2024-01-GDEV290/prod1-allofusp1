using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLooper : MonoBehaviour
{
    public AudioSource audioSource;  
    private int playCount = 0;       
    private int maxPlays = 2;        

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();  
        }

        PlayAudio();  
    }

    void Update()
    {
        if (!audioSource.isPlaying && playCount < maxPlays)
        {
            PlayAudio();  
        }
    }

    void PlayAudio()
    {
        audioSource.Play();  
        playCount++;         
    }
}

