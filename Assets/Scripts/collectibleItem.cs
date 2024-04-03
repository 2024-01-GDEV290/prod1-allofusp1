using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectionScript.instance.CollectItem();
            gameObject.SetActive(false); // Or Destroy(gameObject); if you prefer
        }
    }
}