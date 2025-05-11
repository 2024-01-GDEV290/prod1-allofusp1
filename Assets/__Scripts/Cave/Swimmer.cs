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
	private float _swimBackward = 0;
	//private Coroutine autoRotateActive;
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
		swim(_verticalSwim, _sideSwim, _swimForward, _roll, _swimBackward);
		_swimBackward = Input.GetAxis("Swim Backward") * _swimSpeed;

		//if (Mathf.Abs(_verticalSwim) < 0.05 && Mathf.Abs(_sideSwim) < 0.05 && Mathf.Abs(_swimForward) < 0.05 && Mathf.Abs(_roll) < 0.05 && Mathf.Abs(_swimBackward) < 0.05)
		//{
		//	if (autoRotateActive == null)
		//	{
		//		autoRotateActive = StartCoroutine("autoRotate");
		//	}
		//} else
  //      {
		//	if (autoRotateActive != null)
		//	{
		//		StopCoroutine(autoRotateActive);
		//		this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		//		autoRotateActive = null;
		//	}
  //      }

        //if (Mathf.Abs(_verticalSwim) > 0.05 && Mathf.Abs(_sideSwim) > 0.05 && Mathf.Abs(_swimForward) > 0.05 && Mathf.Abs(_roll) > 0.05 && Mathf.Abs(_swimBackward) > 0.05)
        //{
			//StopCoroutine(autoRotateActive); 
        //}
    }
	
	private void swim(float verticalSwimPower, float sideSwimPower, float swimForwardPower, float rollPower, float swimBackwardPower)
	{
		// Pushes the diver forward
		rb.AddRelativeForce(swimForwardPower * Time.deltaTime * 10, 0, 0);

		// pushes the diver backward
		rb.AddRelativeForce(swimBackwardPower * Time.deltaTime * -10, 0, 0);
		
		// Rotates and rolls the diver
		rb.AddRelativeTorque(-15f * Time.deltaTime * rollPower, sideSwimPower * Time.deltaTime * 100, verticalSwimPower * Time.deltaTime * 100);
	}
	
	//private IEnumerator autoRotate()
	//{
	//	Rigidbody rb = GetComponent<Rigidbody>();
	//	rb.isKinematic = true;
	//	this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
 //       yield return new WaitForEndOfFrame();
		//for (int i = 0; i < 10; i++)
		//{
		//	Debug.Log("step:" + i + " time is" + Time.time);
		//	yield return new WaitForSeconds(1);
		//}
	
}
