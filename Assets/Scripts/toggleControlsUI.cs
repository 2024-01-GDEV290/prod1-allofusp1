using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleControlsUI : MonoBehaviour
{
    public GameObject controlsUI;
    public GameObject holdBUI;

    void Start()
    {
        controlsUI.SetActive(false);
        holdBUI.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            controlsUI.SetActive(true);
            holdBUI.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            controlsUI.SetActive(false);
            holdBUI.SetActive(true);
        }
    }
}

