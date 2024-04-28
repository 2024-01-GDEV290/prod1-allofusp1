using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Map3Pickup : MonoBehaviour
{
    [SerializeField] public GameObject swimmer;
	[SerializeField] public TMP_Text mapDisplay;
	[SerializeField] public TMP_Text returnToSubDisplay;
	
	[SerializeField] private AudioSource CollectSound;
	
	void Start()
	{
		if (MapCount.map3Collected == true)
		{
			MapCount.CheckMapCount();
			mapDisplay.text = MapCount.mapsCollected + "/" + MapCount.mapsNeeded;

			if (MapCount.mapsCollected >= MapCount.mapsNeeded)
			{
				returnToSubDisplay.text = "Map fragments collected. Return to surface";
			}

			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider swimmer)
	{
		MapCount.mapsCollected += 1;
		MapCount.map3Collected = true;

		MapCount.CheckMapCount();
		mapDisplay.text = MapCount.mapsCollected + "/" + MapCount.mapsNeeded;
		
		if (MapCount.mapsCollected >= MapCount.mapsNeeded)
		{
			returnToSubDisplay.text = "Map fragments collected. Return to surface";
		}
		
		CollectSound.Play();
		Destroy(gameObject);
	}
}
