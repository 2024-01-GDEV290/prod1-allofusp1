using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(LoadHeaven());
    }
    private IEnumerator LoadHeaven()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("AustinScene");
    }
}
