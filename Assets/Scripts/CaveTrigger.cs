using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveTrigger : MonoBehaviour
{

    [SerializeField]
    public GameObject CaveEntrance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D CaveEntrance)
    {
        SceneManager.LoadScene("Cave", LoadSceneMode.Additive);
    }
}
