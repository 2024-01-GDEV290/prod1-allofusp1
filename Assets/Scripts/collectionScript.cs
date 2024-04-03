using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectionScript : MonoBehaviour
{
    public static collectionScript instance;

    private int collectedItemCount = 0;
    public int totalItemsToCollect = 5;

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
    }

    public void CollectItem()
    {
        collectedItemCount++;
        Debug.Log("Collected Items: " + collectedItemCount);

        if (collectedItemCount >= totalItemsToCollect)
        {
            Debug.Log("Collected all items!");
            TriggerWinEvent();
        }
    }

    void TriggerWinEvent()
    {
        // Trigger your win condition here
        Debug.Log("Win condition triggered.");
    }
}
