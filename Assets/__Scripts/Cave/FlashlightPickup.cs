using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
	[SerializeField] private GameObject swimmer; 
	[SerializeField] private Light swimmerLight;
	[SerializeField] private TMP_Text consoleDisplay;
	private MeshRenderer mesh;
	
	void Start()
	{
		swimmerLight = swimmerLight.GetComponent<Light>();
		swimmerLight.intensity = 0;
		consoleDisplay.text = "";
		
		mesh = GetComponent<MeshRenderer>();
	}
	
    private void OnTriggerEnter(Collider swimmer)
	{
		GlobalVars.hasFlashlight = true;
		swimmerLight.intensity = 125;
		consoleDisplay.text = "[SUB -> DIVER] Light source acquired. Return to submersible for further directions";
		mesh.enabled = false;
	}
}
