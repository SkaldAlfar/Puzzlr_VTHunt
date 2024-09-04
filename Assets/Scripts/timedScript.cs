using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedScript : MonoBehaviour
{
    private AudioSource audioSource;

    float time = 3f;
    // bool played = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioWithDelay());
    }

    public void Update() {
        
    }

    IEnumerator PlayAudioWithDelay()
    {
        // Optional: perform some action or log that the event has started
        Debug.Log("Game started, waiting 3 seconds to play audio...");

        // Wait for an additional 3 seconds before playing the audio
        yield return new WaitForSeconds(time);

        // Play the audio clip
        audioSource.Play();
    }
}
