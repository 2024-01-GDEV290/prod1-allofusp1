using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectionScript : MonoBehaviour
{
    public static collectionScript instance;

    private int collectedItemCount = 0;
    public int totalItemsToCollect = 5;

    // Audio components for multiple sounds
    public AudioClip[] collectSounds;  // Array of sound clips
    private AudioSource audioSource;
    private int soundIndex = 0;  // Index to track which sound to play next

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Setup the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)  // Add AudioSource if it's not already attached
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    public void CollectItem()
    {
        collectedItemCount++;
        Debug.Log("Collected Items: " + collectedItemCount);

        // Play the next sound in the array
        if (collectSounds.Length > 0)
        {
            audioSource.clip = collectSounds[soundIndex];
            audioSource.Play();
            soundIndex = (soundIndex + 1) % collectSounds.Length;  // Increment and wrap the index
        }

        if (collectedItemCount >= totalItemsToCollect)
        {
            Debug.Log("Collected all items!");
            TriggerWinEvent();
        }
    }

    void TriggerWinEvent()
    {
        Debug.Log("Win condition triggered.");
        SceneManager.LoadScene("streetScene");
    }
}
