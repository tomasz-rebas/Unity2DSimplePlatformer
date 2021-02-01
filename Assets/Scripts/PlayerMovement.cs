using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float sideMovementForce;
    public float jumpForce;

    private Vector2 jumpVector;
    public bool isPlayerGrounded;
    public bool canDoubleJump;

    void Start ()
    {
        jumpVector = new Vector2 (0, jumpForce);
    }

    void Update ()
    {
        if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2 (-sideMovementForce, rb2d.velocity.y);
        }

        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2 (sideMovementForce, rb2d.velocity.y);
        }

        if (Input.GetKey("space"))
        {
            if (isPlayerGrounded)
            {
                canDoubleJump = true;
                Jump();
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                Jump();
            }
        }
    }

    void Jump ()
    {
        rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
        rb2d.AddForce(jumpVector);
    }

    void OnCollisionEnter2D (Collision2D c)
    {
        if (c.gameObject.name == "Floor")
        {
            isPlayerGrounded = true;
        }
    }

    void OnCollisionExit2D (Collision2D c)
    {
        if (c.gameObject.name == "Floor")
        {
            isPlayerGrounded = false;
        }
    }
}
