using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
	[SerializeField]
	private float _swimSpeed = 5;
	
	private float _verticalSwim = 0;
	private float _sideSwim = 0;
	private float _swimForward = 0;
	
	private Rigidbody _rb;
	
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _verticalSwim = Input.GetAxis("Swim Up/Down");
		_sideSwim = Input.GetAxis("Swim Left/Right");
		_swimForward = Input.GetAxis("Swim Forward") * _swimSpeed;	
    }
	
	private void swim(float verticalSwimPower, float sideSwimPower, float swimForwardPower)
	{
		_rb.AddForce(new Vector3(0, 1 * _swimSpeed, 0));
	}
}
