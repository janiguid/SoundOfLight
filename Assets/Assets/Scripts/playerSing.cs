using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSing : playerMovement {

    public Light orb;
    public Rigidbody2D rb2d;
    public Animator anim;
    public AudioSource song;

    public int maxLightRadius;
    public int minLightRadius;
    public float lightRangeIncrementor;
    public float lightRangeDecrementor;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        orb = GameObject.FindGameObjectWithTag("Orb").GetComponent<Light>();
        song = GetComponent<AudioSource>();
        maxLightRadius = 5;
        minLightRadius = 3;
        lightRangeDecrementor = .10f;
        lightRangeIncrementor = .10f;
        rb2d = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {

        //if Lyte is completely stilland x is pressed, play song and singing animation,
        if (Input.GetKeyDown(KeyCode.X) && rb2d.velocity.x == 0 && rb2d.velocity.y == 0)
        {
            Debug.Log("singing");
            anim.SetBool("isSinging", true);
            song.Play();
        }else if (Input.GetKeyUp(KeyCode.X) || rb2d.velocity.x != 0)
        {
            //Debug.Log("stopped");
            //Debug.Log(rb2d.velocity.x);
            anim.SetBool("isSinging", false);
            song.Stop();
        }


        //if Lyte is not moving and 
        //the player presses Z, the light range is increased
        //until it reaches the peak
        if (rb2d.velocity.x == 0)
        {
            if (Input.GetKey(KeyCode.X) && rb2d.velocity.x == 0 && rb2d.velocity.y == 0)
            {
                Debug.Log(rb2d.velocity.x);
                if (orb.range <= maxLightRadius)
                    orb.range += lightRangeIncrementor;
            }
            else if (orb.range >= minLightRadius)
            {
                orb.range -= lightRangeDecrementor;
            }
        }
        else
        {
            if (orb.range > minLightRadius)
            {
                orb.range -= lightRangeDecrementor;
            }
        }
    }

}
