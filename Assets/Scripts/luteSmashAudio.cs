using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luteSmashAudio : MonoBehaviour
{
    [SerializeField] private GameObject Smasher;
    [SerializeField] private NPCInteraction npcStuff;
    [SerializeField] private AudioClip smashSound;  // Reference to the audio clip you want to play
    private AudioSource audioSource;               // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Optionally add an AudioSource if one is not already attached
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // Configure AudioSource properties according to your needs
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Smasher.activeInHierarchy)
        {
            
            // Play the smash sound if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.clip = smashSound;
                audioSource.Play();
            }
        }
    }
}
