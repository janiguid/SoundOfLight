using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingLyteScript : MonoBehaviour {



    public Transform destination;
    public Animator anim;


    //public Animator animator;
    public bool reachedDestination;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(destination.position.x <= transform.position.x && GetComponent<playerMovement>().isGrounded)
        {
            reachedDestination = true;
        }

        if (reachedDestination && GetComponent<playerMovement>().isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<playerMovement>().enabled = false;
            GetComponent<playerSing>().enabled = false;
            GetComponent<playerShoot>().enabled = false;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            anim.SetBool("Ending", true);
            anim.Play("LyteIdle");
        }
    }
    //// Use this for initialization
    //void Start () {
    //       isWalking = true;		
    //}

    //// Update is called once per frame
    //void Update () {
    //       if(transform.position.x != destination.position.x)
    //       {
    //           transform.position = Vector3.MoveTowards(transform.position, destination.position, 0.1f);
    //           if(isWalking == true)
    //           {
    //               animator.Play("LyteWalk");
    //               animator.SetBool("Moving", true);
    //               isWalking = false;
    //           }
    //       }
    //       else 
    //       {
    //           Debug.Log("wahtt");
    //           animator.Play("LyteIdle");
    //           animator.SetBool("Moving", false);

    //       }

    //       Debug.Log(transform.position.x + " " + destination.position.x);
    //}
}
