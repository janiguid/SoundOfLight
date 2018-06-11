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
    public AudioSource birdSounds;
    public AudioSource windSounds;
    public AudioSource themeSong;

    public float orbFinalRange;
    public float orbMaxRange;
    public float orbMovementSpeed;
    public float time;
    public float pauseBeforeSong;
    public float orbRangeIncrementor;
    public float songFadeSpeed;
    public float exitCountdown;

    public bool timerDone;
    public bool reachedDestination;
    public bool orbApexReached;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //once the orbs range caps out, transition back to
        //main menu
        if(orb.range >= orbFinalRange)
        {
            exitCountdown -= Time.deltaTime;
            if(exitCountdown < 0.1)SceneManager.LoadScene(2);
        }


        if(destination.position.x <= transform.position.x && GetComponent<playerMovement>().isGrounded)
        {
            reachedDestination = true;
        }

        //disables player movements once player reaches stop point
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

            //play bird, wind, and theme song once orb reaches apex
            if (orb.transform.position == orbDestination.position && orbApexReached == false)
            {
                orbApexReached = true;
                if (windSounds.isPlaying == false)
                {
                    windSounds.Play();
                }
                if(birdSounds.isPlaying == false)
                {
                    birdSounds.PlayDelayed(1);
                }
                if(themeSong.isPlaying == false)
                {
                    themeSong.Play();
                }

            }

            //increase the rate of which the orb's 
            //light range increases
            if (orbApexReached)
            {
                if (orb.range <= orbFinalRange)
                {
                    orbRangeIncrementor = 0.2f;
                    orb.range += orbRangeIncrementor;
                }
            }
            if (timerDone == true)
            {
                if (orb.range < orbMaxRange)
                {
                    orb.range += 0.02f;
                    if (song.isPlaying == false)
                    {
                        song.Play();
                   
                    }
                }else if(orb.range >= orbMaxRange && orbApexReached == false)
                {
                    //makes orb fly up to the sky
                    anim.SetBool("isLookingUp", true);

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
}
