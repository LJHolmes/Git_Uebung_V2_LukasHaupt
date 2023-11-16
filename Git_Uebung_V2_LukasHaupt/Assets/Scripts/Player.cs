using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    //public float jumpForce = 10f;
    private Rigidbody rb;
    //private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    }
}