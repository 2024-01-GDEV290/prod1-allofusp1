using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip dayAmbient;
    [SerializeField] AudioClip nightAmbient;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public void PlayDaytimeSounds()
    {
        audioSource.clip = dayAmbient;
        audioSource.Play();
    }

    public void PlayNigttimeSounds()
    {
        audioSource.clip = nightAmbient;
        audioSource.Play();
    }
}
