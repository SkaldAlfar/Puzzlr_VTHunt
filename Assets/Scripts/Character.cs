using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // public float Speed = 5f;
    public float speed = 3;
    // public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;
 
    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)) {
            characterController.Move(Vector3.right * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.A)) {
            characterController.Move(Vector3.left * Time.deltaTime * speed);
        }

        // if()

        // var hInput = Input.GetAxis("Horizontal");
        // var vInput = Input.GetAxis("Vertical");
 
        if(characterController.isGrounded)
        {

            if(Input.GetKey(KeyCode.Space))
            {
                moveVelocity.y = jumpSpeed * speed;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        // transform.Rotate(turnVelocity * Time.deltaTime);
    }
}
