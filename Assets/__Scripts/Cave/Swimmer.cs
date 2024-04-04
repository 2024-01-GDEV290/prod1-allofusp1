using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Swimmer : MonoBehaviour
{
	[SerializeField]
	private float _swimSpeed = 2;

	
	private float _verticalSwim = 0;
	private float _sideSwim = 0;
	private float _swimForward = 0;
	private float _roll = 0;
	
	private Rigidbody rb;
	
	public TMP_Text oxyDisplay;
	
	// The 'breathe' coroutine is used to track the player's oxygen level underwater. They have 100 seconds without oxygen.
	private Coroutine breathe;
	
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		
		breathe = StartCoroutine(breathe_time());
    }

    // Update is called once per frame
    void Update()
    {
        _verticalSwim = Input.GetAxis("Swim Up/Down");
		_sideSwim = Input.GetAxis("Swim Left/Right");
		_swimForward = Input.GetAxis("Swim Forward") * _swimSpeed;
		_roll = Input.GetAxis("Barrel Roll Left/Right");

		swim(_verticalSwim, _sideSwim, _swimForward, _roll);
    }
	
	private void swim(float verticalSwimPower, float sideSwimPower, float swimForwardPower, float rollPower)
	{
		// Pushes the diver forward
		rb.AddRelativeForce(swimForwardPower * Time.deltaTime * 10, 0, 0);
		
		// Rotates and rolls the diver
		rb.AddRelativeTorque(-15f * Time.deltaTime * rollPower, sideSwimPower * Time.deltaTime * 100, verticalSwimPower * Time.deltaTime * 100);
	}

	/*
	Currently unused, since I can't get it work yet.
	private void cameraUpdate(GameObject camera)
	{
		// Holds the diver's current position
		Vector3 currentPosition = transform.position;
		
		// Sets the camera at a position close to, but just behind, the diver
		camera.transform.position = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 2);
		
		// Rotates the camera around the diver (in theory)
		camera.transform.RotateAround(currentPosition, 

	}
	
	*/


	IEnumerator breathe_time()
	{
		for (int i = GlobalVars.maxOxyCount; i >= 0; i--)
		{
			if(i == 0)
			{
				SceneManager.LoadScene("2D submarine");
			}
			
			GlobalVars.oxyCount = i;
			oxyDisplay.SetText(GlobalVars.oxyCount.ToString());
			
			yield return new WaitForSeconds(1);
		}
		
	}
	
}
