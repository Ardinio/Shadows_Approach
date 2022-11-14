using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    // Necessary for animation and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;

    // Variables to play with
    public float speed = 2.0f;
    public float horizontalMovement; // = 1[OR]-1[OR]0

    // Start is called before the first frame update
    private void Start()
    {
        // Define the gameobjects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check direction given by player
        horizontalMovement = Input.GetAxisRaw("Horizontal");
    }

    // Handles running the physics
    private void FixedUpdate()
    {
        // Move the character left and right 
        rb2D.velocity = new Vector2(horizontalMovement*speed, rb2D.velocity.y);
        Flip(horizontalMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontalMovement));
    }

    private void Flip (float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
