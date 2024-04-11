using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookPickup : MonoBehaviour
{
	[SerializeField] public TMP_Text LogDisplay;
	
    private void OnTriggerEnter(Collider swimmer)
	{
		
		GlobalVars.hasLog = true;
	
		LogDisplay.text = "> Ship's log recovered - return to submersible for deciphering";
	
		Destroy(gameObject);
	}
}
