using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Cinemachine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueTrigger;
    public GameObject interactionText;
    public float interactionRange = 3f; // Interaction range
    public PlayerMovement fpsController;
    public GameObject transitionCamera ;
   
    

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

            if (hit.collider.CompareTag("door"))
            {
                interactionText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    transitionCamera.SetActive(true);
                    interactionText.SetActive(false);
                    StartCoroutine(LoadTree());
                   // SceneManager.LoadScene("treeScene");
                }
            }

            if (hit.collider.CompareTag("collectible"))
            {
                interactionText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    collectionScript.instance.CollectItem();
                    hit.collider.gameObject.SetActive(false); 
                }
            }

            if (hit.collider.CompareTag("paper"))
            {
                interactionText.SetActive(true);
                Debug.Log("Hit: " + hit.collider.name);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    dialogueTrigger.SetActive(true);
                    fpsController.ToggleMovement(false); //lock character movement
                    

                }
            }

            if (hit.collider.CompareTag("rock"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("bedroomScene");
                }
                
            }

            if (hit.collider.CompareTag("bedroomDoor"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("collectionScene");
                }

            }

            Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);
        }

        else
        {
            interactionText.SetActive(false);
        }

    }
    private IEnumerator LoadTree()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("treeScene");
    }
}


