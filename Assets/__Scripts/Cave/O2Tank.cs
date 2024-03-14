using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Tank : MonoBehaviour
{
	private Rigidbody _rb;
	
	[SerializeField]
	public GameObject swimmer;
	
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
		_rb.AddTorque(6f, 4f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider swimmer)
	{
		GlobalVars.oxyCount = GlobalVars.maxOxyCount;
		Debug.Log("Entered");
	}
}
