using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueTrigger; // Assign your DialogueManager GameObject here in the Inspector
    public float interactionRange = 3f; // Interaction range, adjust as needed
    //public LayerMask npcLayer; // Assign a layer for the player to filter the raycast


    void Start()
    {
        dialogueTrigger.SetActive(false);
    }

    void Update()
    {
        CheckForNPC();
    }

    void CheckForNPC()
    {
        // Perform a raycast forward from the NPC's position
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("NPC")) // Make sure your player GameObject has the "Player" tag
            {
                Debug.Log("Hit: " + hit.collider.name);
                // Optionally, check for a key press to initiate dialogue
                if (Input.GetKeyDown(KeyCode.E)) // Assuming 'E' is the interact key
                {
                    dialogueTrigger.SetActive(true); // Activate the dialogue, assuming the dialogue manager handles activation appropriately
                    // Alternatively, call a method on the DialogueManager to start the dialogue
                    // dialogueTrigger.GetComponent<DialogueManager>().StartDialogue();
                }
            }
        }

        // Optionally, draw the ray in the Scene view for debugging
        Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);
    }
}

