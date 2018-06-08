using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    private Animator animator;
    public AudioSource footsteps;
    [SerializeField]
    private static Rigidbody2D rb2D;

    //horizontal movement
    [SerializeField]
    private float xMove, movementSpeed;

    //vertical movement
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private bool jumpCall, jumping;
    public bool isGrounded;

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
        jumpHeight =325;


        //direction variables
        isFacingRight = true;


	}

    // Update is called once per frame
    void Update()
    {
        

        //gets the y velocity
        float verticalVelocity = rb2D.velocity.y;

        //returns -1 or 1 depending on which arrow keys are pressed
        float horizontalVelocity = Input.GetAxis("Horizontal");
        xMove = Input.GetAxis("Horizontal");


        //to ensure tight ground detection
        if (verticalVelocity != 0) isGrounded = false;


        //If x velocity is not 0, play walking animation
        //and play footsteps sounds
        if (horizontalVelocity != 0 && isGrounded)
        {
            animator.SetBool("Moving", true);
            if (footsteps.isPlaying == false)
            {
                if (isGrounded)
                {
                    footsteps.Play();
                }

            }
        }
        else if (horizontalVelocity == 0 && isGrounded)
        {
            animator.SetBool("Moving", false);
            if (footsteps.isPlaying == true)
            {
                footsteps.Stop();
            }
        }


        //stops the footsteps sounds once player leaves ground
        if (!isGrounded)footsteps.Stop();
        

        //this deals with jumping animations
        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }else if (!isGrounded)
        {
            animator.SetBool("isGrounded", false);
        }

        //these are required to determine which animation to play
        animator.SetFloat("xVel", horizontalVelocity);
        animator.SetFloat("yVel", verticalVelocity);

        //this gets inputs to call the jump function
        //we do this in the update function because
        //we want more responsive jumps
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded && verticalVelocity < 0.01)
        {
            isGrounded = false;
            jumpCall = true;
            
            Debug.Log(verticalVelocity);
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
        Debug.Log("before walk");
        rb2D.velocity = new Vector2(xMove * movementSpeed, rb2D.velocity.y);
        Debug.Log(rb2D.velocity.x);
        


        determineDirection();

        
        if (jumpCall)
        {
            Jump();
        }

    }

    public void Jump()
    {
        //https://www.youtube.com/watch?v=7KiK0Aqtmzc
        //essentially increases gravity on the way down

        isGrounded = false;

        rb2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

        jumpCall = false;

    }

    public void determineDirection()
    {
        //if x velocity is greater than 0, lyte is facing right
        if (xMove > 0)
        {
            isFacingRight = true;
        }
        else if (xMove < 0)
        {
            isFacingRight = false;
        }
    }






}
