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
	
	
	// Camera is not a child of the swimmer, but is in a fixed position relative to swimmer
	public GameObject camera;
	
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
		
		/*
		Debug.Log(_verticalSwim);
		Debug.Log(_sideSwim);
		Debug.Log(_swimForward);
		*/
		
		swim(_verticalSwim, _sideSwim, _swimForward, _roll);
		
		cameraUpdate(camera);
    }
	
	private void swim(float verticalSwimPower, float sideSwimPower, float swimForwardPower, float rollPower)
	{
		rb.AddRelativeForce(swimForwardPower * Time.deltaTime * 10, 0, 0);
		
		rb.AddRelativeTorque(-20 * rollPower * Time.deltaTime, sideSwimPower * Time.deltaTime * 100, verticalSwimPower * Time.deltaTime * 100);
	}

	private void cameraUpdate(GameObject camera)
	{
		Vector3 currentPosition = transform.position;
		camera.transform.position = new Vector3(currentPosition.x - 3, currentPosition.y, currentPosition.z);
		
		camera.transform.rotation = transform.rotation;
		camera.transform.Rotate(0, 90, 0);
	}


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
