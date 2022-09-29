using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public bool isJumping = false;
    public float jumpForce;
    public bool isGrounded;
    public bool canDoubleJump;

    public Transform groundcheckLeft;
    public Transform groundcheckRight;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private int compteur;


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundcheckLeft.position, groundcheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        


        MovePlayer(horizontalMovement);
    }

    

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        //if (isJumping == true)
        //{
        //    rb.AddForce(new Vector2(0f, jumpForce));
        //    isJumping = false;

        //}
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        isJumping = false;
    }

}
