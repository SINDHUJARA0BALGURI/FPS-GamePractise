using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private Vector3 moveDirection;

    public float speed = 5f;
    private float gravity = 20f;

    public float jumpForce = 10f;
    private float verticalVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovingThePlayer();
    }

    void MovingThePlayer()
    {
        //move Player

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f,
                                     Input.GetAxis("Vertical"));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);


    } // move player

    void ApplyGravity()
    {

        verticalVelocity -= gravity * Time.deltaTime;

        // jump
        PlayerJump();

        moveDirection.y = verticalVelocity * Time.deltaTime;

    } // apply gravity

    void PlayerJump()
    {

        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }

    }
}
