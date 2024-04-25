using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Map1Pickup : MonoBehaviour
{
    [SerializeField] public GameObject swimmer;
	[SerializeField] public TMP_Text mapDisplay;
	[SerializeField] public TMP_Text returnToSubDisplay;
	
	void Start()
	{
		if (MapCount.map1Collected == true)
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
		MapCount.map1Collected = true;

		MapCount.CheckMapCount();
		mapDisplay.text = MapCount.mapsCollected + "/" + MapCount.mapsNeeded;
		
		if (MapCount.mapsCollected >= MapCount.mapsNeeded)
		{
			returnToSubDisplay.text = "Map fragments collected. Return to surface";
		}
		
		Destroy(gameObject);
	}
}
