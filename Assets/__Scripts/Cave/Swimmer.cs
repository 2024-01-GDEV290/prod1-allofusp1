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

	
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
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
	
}
