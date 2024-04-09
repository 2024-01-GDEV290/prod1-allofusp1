using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCave1 : MonoBehaviour
{
    [SerializeField]
    public GameObject CaveEntrance;

    private void OnTriggerEnter2D(Collider2D CaveEntrance)
    {
        SceneManager.LoadScene("Cave1", LoadSceneMode.Single);
    }
}
