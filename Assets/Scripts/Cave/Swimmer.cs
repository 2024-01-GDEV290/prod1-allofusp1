using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
	
	public int oxyCount = 100;
	public TMP_Text oxyDisplay;
	
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
		
		/*
		Debug.Log(_verticalSwim);
		Debug.Log(_sideSwim);
		Debug.Log(_swimForward);
		*/
		
		swim(_verticalSwim, _sideSwim, _swimForward, _roll);
		
		Invoke("breathe", 1);
    }
	
	private void swim(float verticalSwimPower, float sideSwimPower, float swimForwardPower, float rollPower)
	{
		rb.AddRelativeForce(swimForwardPower * Time.deltaTime * 10, 0, 0);
		
		rb.AddRelativeTorque(-0.05f * rollPower, sideSwimPower * Time.deltaTime * 100, verticalSwimPower * Time.deltaTime * 100);
	}

	private void breathe()
	{
		oxyCount -= 1;
		oxyDisplay.SetText(oxyCount.ToString());
	}
	
}
