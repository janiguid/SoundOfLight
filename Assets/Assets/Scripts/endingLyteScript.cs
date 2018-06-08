using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingLyteScript : MonoBehaviour {



    public Transform destination;
    public Transform orbDestination;
    public Transform songFadePoint;
    public Animator anim;
    public Light orb;
    public AudioSource song;
    public AudioSource footsteps;

    public float orbFinalRange;
    public float orbMaxRange;
    public float orbMovementSpeed;
    public float time;
    public float pauseBeforeSong;
    public float orbRangeIncrementor;
    public float songFadeSpeed;

    public bool timerDone;
    public bool reachedDestination;
    public bool orbApexReached;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(orb.range >= orbFinalRange)
        {
            SceneManager.LoadScene(0);
        }

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
            orb.GetComponent<orbFollow>().enabled = false;
            anim.SetBool("Ending", true);
            footsteps.Stop();
            Timer(pauseBeforeSong);
            if (orb.transform.position == orbDestination.position && orbApexReached == false)
            {
                orbApexReached = true;
            }

            if (orbApexReached)
            {
                if (orb.range <= orbFinalRange)
                {
                    orb.range += orbRangeIncrementor;
                }
            }
            if (timerDone == true)
            {
                if (orb.range < orbMaxRange)
                {
                    orb.range += 0.08f;
                    if (song.isPlaying == false)
                    {
                        song.Play();
                   
                    }
                }else if(orb.range >= orbMaxRange && orbApexReached == false)
                {
                    orb.GetComponent<Transform>().position = Vector3.MoveTowards(orb.GetComponent<Transform>().position,
                        orbDestination.position, orbMovementSpeed);
                    
                    if(orb.transform.position.y >= songFadePoint.position.y)
                    {
                        song.volume -= songFadeSpeed;
                    }
                    
                }
            }

            
        }


    }

    void Timer(float requiredTime)
    {
        time += Time.fixedDeltaTime;
        if(time > requiredTime)
        {
            timerDone = true;
            time = 0;
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
