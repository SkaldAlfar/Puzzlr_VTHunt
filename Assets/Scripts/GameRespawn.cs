using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public GameObject Player;
    private Transform posVector;

    void Start() {
        GameObject initialPosition = new GameObject("InitialPosition");
        initialPosition.transform.position = Player.transform.position;
        posVector = initialPosition.transform;
        Debug.Log("Set initial position: "  + posVector);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y < threshold) {
            Player.transform.position = posVector.position;
            // Destroy(this.gameObject);
            // Instantiate(Player, this.transform.position, this.transform.rotation);
            Debug.Log("Old location: " + posVector);
        }

    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("fire1")){
            // StartCoroutine(ResetPosition());
            GameObject firePos = new GameObject("FirePos");
            firePos.transform.position = col.transform.position;
            posVector = firePos.transform;
        }
    }

    // private IEnumerator ResetPosition() {
    //     Debug.Log("Resetting position to: " + posVector);
    //     yield return new WaitForSeconds(0.1f); // Slight delay to ensure smooth reset
    //     transform.position = posVector;
    // }
}
