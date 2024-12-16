using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed;
    public int startingPoint;
    public Transform[] points;  // An array of transform points (postions where the platform needs to move)
    private int i;  // index of array

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; // Setting the position of the platform to the position of one of the points using index "startingPoint"
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f){
            i++;
            if (i == points.Length){
                i = 0;
            }
        }

        // Move the platform to the point position with index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
