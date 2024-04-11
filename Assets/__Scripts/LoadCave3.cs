using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCave3 : MonoBehaviour
{
    [SerializeField]
    public GameObject CaveEntrance;

    private void OnTriggerEnter2D(Collider2D CaveEntrance)
    {
        SceneManager.LoadScene("Cave3", LoadSceneMode.Single);
    }
}
