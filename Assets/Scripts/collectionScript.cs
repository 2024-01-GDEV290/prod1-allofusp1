using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectionScript : MonoBehaviour
{
    public static collectionScript instance;

    private int collectedItemCount = 0;
    public int totalItemsToCollect = 5;

    
    public AudioClip[] collectSounds;  
    private AudioSource audioSource;
    private int soundIndex = 0;  

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

        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)  
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    public void CollectItem()
    {
        collectedItemCount++;
        Debug.Log("Collected Items: " + collectedItemCount);

        
        if (collectSounds.Length > 0)
        {
            audioSource.clip = collectSounds[soundIndex];
            audioSource.Play();
            soundIndex = (soundIndex + 1) % collectSounds.Length;  
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
