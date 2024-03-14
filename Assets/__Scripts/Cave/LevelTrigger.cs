using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
	[SerializeField]
	public GameObject swimmer;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider swimmer)
	{
		SceneManager.LoadScene("2D submarine");
	}
}
