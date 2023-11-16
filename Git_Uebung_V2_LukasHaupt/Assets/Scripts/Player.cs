using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    private bool isGrounded;


    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Animator animator;
    private bool isWalking = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        // Add this to rotate the player to the direction of movement
        if (movement != Vector3.zero) // Prevents the player from rotating when not moving
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up); // Reverse the movement vector
            transform.rotation = toRotation;
        }

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump input
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check if the player is moving
        isWalking = (moveHorizontal != 0f || moveVertical != 0f);

        // Update the Animator parameter to switch between idle and walk animations
        animator.SetBool("IsWalking", isWalking);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}