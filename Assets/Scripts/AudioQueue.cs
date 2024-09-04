using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQueue : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;
    private bool audioPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (audioPlayed == false){
            source.Play();
            audioPlayed = true;
        }
    }
}
