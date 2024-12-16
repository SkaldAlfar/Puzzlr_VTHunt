using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private float idleTime;
    public float idleThreshold = 60f;
    // public AudioSource soundSource;
    // private bool firstAudio = false;

    // float horizontalMove = 0f;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isTouchingPacman = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        idleTime = 0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        // Reset idle time if any key is pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            idleTime = 0f;
            // Left/right
            if (Input.GetKey(KeyCode.D)){
                transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                spriteRenderer.flipX = false;
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }

            if (Input.GetKey(KeyCode.A)){
                transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
                spriteRenderer.flipX = true;
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }

            if (isTouchingPacman)
            {
                // Pacman up/down
                if (Input.GetKey(KeyCode.W) && isTouchingPacman){
                    transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
                    animator.SetBool("isRunning", true);
                    animator.SetBool("isIdle", false);
                    Debug.Log("Up");
                }

                if (Input.GetKey(KeyCode.S)){
                    transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
                    animator.SetBool("isRunning", true);
                    animator.SetBool("isIdle", false);
                    Debug.Log("Down");
                }
            }
                
            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !isTouchingPacman){
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
        else {
            // No input, increment idle timer
            idleTime += Time.deltaTime;

            // If idle time exceeds threshold, trigger idle animation
            if (idleTime >= idleThreshold)
            {
                animator.SetBool("isIdle", true);
                animator.SetBool("isRunning", false);
            }
            else
            {
                // If player is standing but not idle (e.g., just stopped moving)
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Floor"))
        {
            // Reset jump count when the player lands
            jumpCount = 0;
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("pacman"))
        {
            isTouchingPacman = true;
            rb.gravityScale = 0f;
            Debug.Log("Touching Pacman");
        }
        else if (collision.gameObject.CompareTag("Floor")) {
            isTouchingPacman = false;
            rb.gravityScale = 1f;
            Debug.Log("Touching Floor");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Detect when the player leaves the ground
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("pacman"))
        {
            isGrounded = false;
        }
    }
}
