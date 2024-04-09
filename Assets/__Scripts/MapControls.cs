using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapControls : MonoBehaviour
{
	[SerializeField] private GameObject DarkSide;
	private BoxCollider2D DarkSideCollider;
	
	[SerializeField] private GameObject FoggySide;
	private BoxCollider2D FoggySideCollider;
	
	[SerializeField] private TMP_Text objectiveDisplay;
	
	void Start()
	{
		DarkSideCollider = DarkSide.GetComponent<BoxCollider2D>();
		FoggySideCollider = FoggySide.GetComponent<BoxCollider2D>();
		
		if (GlobalVars.hasFlashlight == true)
		{
			DarkSideCollider.enabled = false;
			objectiveDisplay.text = ("Now that I have a light source, I should be able to explore the hidden area for the ship's logs. Maybe they will help point me in the ship's direction...");
		}
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
