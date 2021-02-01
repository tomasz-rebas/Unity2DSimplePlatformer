using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float sideMovementForce;
    public float jumpForce;
    public float wallJumpReducer;

    public bool isPlayerGrounded;
    public bool canDoubleJump;
    public bool isTouchingTheWall;

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

        if (Input.GetKeyDown("space"))
        {
            if (isPlayerGrounded)
            {
                canDoubleJump = true;
                Jump();
            }
            else if (isTouchingTheWall && !isPlayerGrounded)
            {
                WallJump();
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                Jump();
            }
        }
    }

    private void Jump ()
    {
        rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
        rb2d.AddForce
        (
            new Vector2 (0, jumpForce)
        );
    }

    private void WallJump ()
    {
        rb2d.velocity = new Vector2 (0, 0);
        rb2d.AddForce
        (
            new Vector2
            (
                wallJumpReducer * jumpForce,
                wallJumpReducer * jumpForce
            )
        );
    }

    void OnCollisionEnter2D (Collision2D c)
    {
        switch (c.gameObject.name)
        {
            case "Floor": 
                isPlayerGrounded = true;
                break;
            case "ExteriorWallLeft":
                isTouchingTheWall = true;
                break;
            default:
                break;
        }
    }

    void OnCollisionExit2D (Collision2D c)
    {
        switch (c.gameObject.name)
        {
            case "Floor": 
                isPlayerGrounded = false;
                break;
            case "ExteriorWallLeft":
                isTouchingTheWall = false;
                break;
            default:
                break;
        }
    }
}
