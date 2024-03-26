using System.Collections;
using UnityEngine;
using TMPro; // Updated namespace for TextMeshPro

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Updated to use TMP_Text
    public string[] sentences; // Array of sentences you want to cycle through
    private int index = 0;
    public float typingSpeed = 0.02f; // Speed of typing

    void Start()
    {
        StartCoroutine(TypeSentence());
    }

    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (dialogueText.text == sentences[index]) // Check if typing has finished
            {
                NextSentence();
            }
            else
            {
                // If the sentence is still typing out, instantly complete it on click
                StopAllCoroutines(); // Stops the current typing coroutine
                dialogueText.text = sentences[index]; // Instantly display the full sentence
            }
        }
    }


    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = ""; // Clear the text
            StartCoroutine(TypeSentence());
        }
        else
        {
            // New: Check if we're on the last sentence and it has finished typing
            if (dialogueText.text == sentences[index])
            {
                dialogueText.text = ""; // Clear the text for the last time
                index = 0; // Reset index to 0 or according to your needs
                           // Optionally hide the dialogue UI here or trigger other actions
                            gameObject.SetActive(false); // Example to hide the dialogue object
            }
            else
            {
                // If the last sentence hasn't finished typing, let it complete
                StopAllCoroutines(); // Stops the current typing coroutine
                dialogueText.text = sentences[index]; // Display the full sentence instantly
            }
        }
    }



}
