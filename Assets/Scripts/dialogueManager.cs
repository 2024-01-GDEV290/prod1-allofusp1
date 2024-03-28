using System.Collections;
using UnityEngine;
using TMPro; // Updated namespace for TextMeshPro

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; 
    public string[] sentences; // Array of sentences to cycle through
    private int index = 0;
    public float typingSpeed = 0.02f; // Speed of typing
    public FirstPersonController fpsController;
    

    void Start()
    {
        StartCoroutine(TypeSentence());
    }

    void Update()
    {
        
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
            dialogueText.text = ""; // Clear the last sentence

            StartCoroutine(TypeSentence());
        }
        else
        {
            //Check if last sentence has finished typing
            if (dialogueText.text == sentences[index])
            {
                dialogueText.text = ""; // Clear the text 
                index = 0; // Reset index to 0 
                           
                gameObject.SetActive(false); // Hide the dialogue object
                fpsController.ToggleMovement(true); // unlock character movement
                
                
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
