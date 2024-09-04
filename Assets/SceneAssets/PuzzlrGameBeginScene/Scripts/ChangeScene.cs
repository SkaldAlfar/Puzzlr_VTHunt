using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro component
    public float blinkInterval = 0.5f;  // Time interval between blinks

    private bool isBlinking = false;    // Track the blinking state
    public Image fadeImage;  // Reference to the UI Image used for fading
    public float fadeDuration = 1f;  // Duration of the fade effect
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(FadeOut("PuzzlrPixelScene"));
        }
    }

    IEnumerator Blink()
    {
        // Loop the blinking effect
        while (true)
        {
            // Toggle the visibility of the text
            isBlinking = !isBlinking;
            textMeshPro.enabled = isBlinking;

            // Wait for the next blink
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void FadeToScene(string sceneName)
    {
        // Start the fade-out and load the new scene
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName)
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        // Fade from transparent to black
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // After fading out, load the new scene
        SceneManager.LoadScene(sceneName);
    }
}
