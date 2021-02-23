using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    //horizontal 
    //player horizontal script
    public float speed = 20f;


    //vertical
    //current falling speed
    Vector3 velocity;
    public float gravity = -50f;
    public float jumpHeight = 5f;


    //ground check
    //buffer object that will check ground distance
    public Transform grndCk;
    //radius if there is an object in which the player is on the ground
    public float groundDistance = 0.4f;
    //masks to exclude a player from the check
    [SerializeField] private LayerMask playerMask;
    bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        isGrounded = groundCheck();
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpFunction();
        }
        horizonalMovement();
        fallFunction();
    }
    void horizonalMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //the direction in which the player will move. Based on local direction.
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }

    void fallFunction()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    bool groundCheck()
    {
        return (Physics.OverlapSphere(grndCk.position, groundDistance, playerMask).Length != 0);
    }

    void jumpFunction()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}