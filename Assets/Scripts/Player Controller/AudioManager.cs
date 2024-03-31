using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip dayAmbient;
    [SerializeField] AudioClip nightAmbient;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip failure;
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

    public void PlaySuccess()
    {
        audioSource.PlayOneShot(success);
    }

    public void PlayFailure()
    {
        audioSource.PlayOneShot(failure);
    }
}
