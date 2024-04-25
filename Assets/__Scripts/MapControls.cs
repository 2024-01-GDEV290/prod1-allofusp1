using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MapControls : MonoBehaviour
{
	[SerializeField] private GameObject DarkSide;
	private BoxCollider2D DarkSideCollider;
	
	[SerializeField] private GameObject FoggySide;
	private BoxCollider2D FoggySideCollider;
	
	[SerializeField] private TMP_Text objectiveDisplay;
	
	[SerializeField] private GameObject mapDisplay;
	private bool mapDisplayActive = false;
	[SerializeField] private GameObject foundMapDisplay;
	[SerializeField] private TMP_Text noDataDisplay;
	
	void Start()
	{
		mapDisplay.SetActive(mapDisplayActive);
		foundMapDisplay.SetActive(false);
		
		DarkSideCollider = DarkSide.GetComponent<BoxCollider2D>();
		FoggySideCollider = FoggySide.GetComponent<BoxCollider2D>();
		
		if (GlobalVars.hasFlashlight == true)
		{
			DarkSideCollider.enabled = false;
			objectiveDisplay.text = ("Now that I have a light source, I should be able to explore the hidden area for the ship's logs. Maybe they will help point me in the ship's direction...");
		}
		
		if (GlobalVars.hasMap == true)
		{
			FoggySideCollider.enabled = false;
			objectiveDisplay.text = "Now that I've reassembled this map, I should be able to find their last location. Better head out!";
			foundMapDisplay.SetActive(true);
			noDataDisplay.text = "";
		}
		
		if (GlobalVars.hasLog == true)
		{
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
		}
	}
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Toggle Map Display") == true)
		{
			mapDisplayActive = !mapDisplayActive;
			mapDisplay.SetActive(mapDisplayActive);
		}
    }
}
