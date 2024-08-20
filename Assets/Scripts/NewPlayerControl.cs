using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    // float horizontalMove = 0f;
    public Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        // animator.SetFloat("Speed", horizontalMove);

        // Left/right
        if (Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A)){
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        
        // Jump
        // TODO: Change jump so it doesn't build on the last
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
