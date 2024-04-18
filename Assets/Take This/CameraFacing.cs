//	CameraFacing.cs 
//	original by Neil Carter (NCarter)
//	modified by Hayden Scott-Baron (Dock) - http://starfruitgames.com
//  allows specified orientation axis


using UnityEngine;
using System.Collections;
using Cinemachine;

public class CameraFacing : MonoBehaviour
{
	public Camera cameraToLookAt;
	//public CinemachineVirtualCamera camToLookAt;
	void Awake() {
		cameraToLookAt = Camera.main; 

	}
	void Update() 
	{
        Vector3 v = cameraToLookAt.transform.position - transform.position;
		v.x = v.z = 0.0f;
		transform.LookAt(cameraToLookAt.transform.position - v); 
	}
}