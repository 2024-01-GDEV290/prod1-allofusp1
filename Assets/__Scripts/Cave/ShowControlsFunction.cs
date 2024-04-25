using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowControlsFunction : MonoBehaviour
{
	[SerializeField] public TMP_Text controlsText;
	[SerializeField] public GameObject controlsOverlay;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Controls Info") == true)
		{
			controlsText.text = "";
			controlsOverlay.SetActive(true);
		} else {
			controlsText.text = "Hold B for controls info";
			controlsOverlay.SetActive(false);
		}
    }
}
