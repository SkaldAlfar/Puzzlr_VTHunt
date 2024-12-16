using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceShoot : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;
    Renderer pieceRender;
    public GameObject speechBubble;
    private bool audioPlayed = false;
    private bool pieceCollected = false;
    private bool pieceVisible = true;
    private bool bubbleVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
        pieceRender = GetComponent<Renderer>();
        speechBubble.SetActive(bubbleVisible);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        pieceVisible = false;
        pieceCollected = true;
        bubbleVisible = true;

        if (audioPlayed == false && pieceCollected){
            source.Play();
            audioPlayed = true;
            pieceRender.enabled = pieceVisible;
            speechBubble.SetActive(bubbleVisible);
        }
    }
}
