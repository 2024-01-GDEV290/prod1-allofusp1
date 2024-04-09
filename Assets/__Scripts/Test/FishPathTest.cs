using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPathTest : MonoBehaviour
{
	[SerializeField] private float speedMultiplier = 1;
	
	[SerializeField] private Transform pointA;
	[SerializeField] private Transform pointB;
	[SerializeField] private Transform pointAB;
	
	[SerializeField] private Transform pointC;
	[SerializeField] private Transform pointBC;
	
	[SerializeField] private Transform fish;
	
	private float interpolateAmount;

    // Update is called once per frame
    void Update()
    {
        interpolateAmount = (interpolateAmount + (Time.deltaTime * speedMultiplier)) % 1f;
		
		
		pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolateAmount);
		pointBC.position = Vector3.Lerp(pointB.position, pointC.position, interpolateAmount);

		fish.position = Vector3.Lerp(pointAB.position, pointBC.position, interpolateAmount);
    }
}
