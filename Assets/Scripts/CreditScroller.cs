using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroller : MonoBehaviour
{
    public RectTransform creditsText;
    public float scrollSpeed = 20f;
    public float endPosition = 1500f;  // The position at which the text will stop scrolling

    void Update()
    {
        // Move the text upward at the specified scroll speed
        if (creditsText.localPosition.y < endPosition)
        {
            creditsText.position += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
        }
        else
        {
            this.enabled = false; // Disable the script when end position is reached
            // Optionally deactivate the text or do other actions like loading a new scene
            creditsText.gameObject.SetActive(false);
            // Uncomment the line below to load another scene, e.g., the main menu
            // UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}


