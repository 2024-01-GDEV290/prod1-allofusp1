using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueTrigger;
    public GameObject interactionText;
    public float interactionRange = 3f; // Interaction range
    public FirstPersonController fpsController;

    void Start()
    {
        dialogueTrigger.SetActive(false);
        interactionText.SetActive(false);

    }

    void Update()
    {
        CheckForNPC();

        if (dialogueTrigger.activeInHierarchy)
        {
            interactionText.SetActive(false);
        }
    }

    void CheckForNPC()
    {
        // Perform a raycast forward from the players' position
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("NPC")) 
            {
                interactionText.SetActive(true);
                Debug.Log("Hit: " + hit.collider.name);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    dialogueTrigger.SetActive(true);
                    fpsController.ToggleMovement(false); //lock character movement

                }
            }

            

            Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);
        }

        else
        {
            interactionText.SetActive(false);
        }

    }
}

