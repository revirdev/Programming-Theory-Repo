using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 12f;
    private float gravity = -9.81f * 2;
    private float jumpHeight = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;
    private float groundDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Check if player is on the ground and set isGrounded to TRUE
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset velocity.y 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get user input movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Move player with specific way
        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        // Make player jump
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Gravity for player: v = 1/2 g*t^2
        velocity.y += gravity * Time.deltaTime; // g * t
        controller.Move(velocity * Time.deltaTime); // 
    }
}
