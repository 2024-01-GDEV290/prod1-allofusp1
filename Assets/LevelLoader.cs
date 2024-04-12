using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] GameEventTrigger transitionTrigger;
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, delay));
    }

    IEnumerator LoadLevel(int levelIndex, float delay)
    {
        transitionTrigger.Raise();
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(levelIndex);
    }
}
