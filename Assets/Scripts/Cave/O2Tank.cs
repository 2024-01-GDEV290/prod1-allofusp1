using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Tank : MonoBehaviour
{
	private Rigidbody _rb;
	
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
		_rb.AddTorque(0.5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
