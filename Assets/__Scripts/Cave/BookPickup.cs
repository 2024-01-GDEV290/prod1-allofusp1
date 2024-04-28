using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookPickup : MonoBehaviour
{
	[SerializeField] public TMP_Text LogDisplay;
	[SerializeField] private AudioSource CollectSound;
	
    private void OnTriggerEnter(Collider swimmer)
	{
		
		GlobalVars.hasLog = true;
	
		LogDisplay.text = "[SUB > DIVER] Ship's log recovered - return to surface for deciphering";
	
		CollectSound.Play();
		Destroy(gameObject);
	}
}
