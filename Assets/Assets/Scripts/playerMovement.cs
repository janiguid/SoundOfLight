using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rb2D;

    //horizontal movement
    [SerializeField]
    private float xMove, movementSpeed;

    //vertical movement
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private bool jumpCall, jumping, isGrounded;

    //direction variables
    public bool isFacingRight;

	// Use this for initialization
	void Start () {
        //this gives us access to the Rigidbody2D
        //of the gameObject this script is attached to
        //*Rigidbody is what allows us to apply physics
        //the object
        rb2D = GetComponent<Rigidbody2D>();

        //this gives us access to the animator,
        //which allows us to control what animation
        //plays when
        animator = GetComponent<Animator>();


        //setting movement variables
        movementSpeed = 5;
        jumpHeight =160;


        //direction variables
        isFacingRight = true;
	}

    // Update is called once per frame
    void Update()
    {
        float horizontalVelocity = Input.GetAxis("Horizontal");

        if (horizontalVelocity != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        animator.SetFloat("xVel", horizontalVelocity);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            jumpCall = true;
        }

    }

    //The difference between Update and FixedUpdate
    //is that, unlike Update, FixedUpdate is not dependent on the 
    //hardware. Essentially,
    //the faster the computer, the more Update calls
    //are called. 
    private void FixedUpdate()
    {
        //https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-character-controllers?playlist=17120
        //Input.GetAxis returns -1 if the player presses
        //the left arrow and returns 1 if the player presses
        //the right arrow. We multiply this value to 
        //movementSpeed to affect the direction the player
        //goes to.
        xMove = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(xMove * movementSpeed, rb2D.velocity.y);
        

        determineDirection();

        Debug.Log(rb2D.velocity.y);

        if (jumpCall)
        {
            Jump();
        }

    }

    public void Jump()
    {
        //https://www.youtube.com/watch?v=7KiK0Aqtmzc
        //essentially increases gravity on the way down
        Debug.Log("nani");

        isGrounded = false;

        rb2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

        jumpCall = false;


    }

    public void determineDirection()
    {
        if (xMove > 0)
        {
            isFacingRight = true;
        }
        else if (xMove < 0)
        {
            isFacingRight = false;
        }
    }

    //If the collider under the player's feet comes in contact
    //with a platform tagged as ground, isGrounded is set to 
    //true
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        
    }




}
