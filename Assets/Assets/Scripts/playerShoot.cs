using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : playerMovement {

    public GameObject magicOrb;
    public float magicOrbSpeed;
    public bool thrown;
    public GameObject magicOrbPlaceholder;
    public bool flying;

    //these are the bounds of the ball
    public Transform leftLimit;
    public Transform rightLimit;


	// Use this for initialization
	void Start () {
        magicOrb = GameObject.FindGameObjectWithTag("Orb");
        magicOrbPlaceholder = GameObject.FindGameObjectWithTag("OrbPlaceholder");
        magicOrbSpeed = 0.25f;
        thrown = false;
        isFacingRight = true;
        
        
	}
	
	// Update is called once per frame
	private void Update () {

        determineDirection();

        if (isFacingRight == true)
        {
            ShootRight();
        }else if(isFacingRight == false)
        {
            ShootLeft();
        }
        
        if (Input.GetKey(KeyCode.Z) && thrown == true )
        {
            flying = false;
        }
	}

    void ShootRight()
    {
       
        

        if (Input.GetKey(KeyCode.Z) && thrown == false)
        {
            //returns if orb is going out of bounds
            if (magicOrb.transform.position.x > rightLimit.position.x) return;

            magicOrb.transform.position = new Vector3(magicOrb.transform.position.x + magicOrbSpeed,
                magicOrb.transform.position.y, magicOrb.transform.position.z);
            flying = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            thrown = !thrown;
        }
    }

    void ShootLeft()
    {


        if (Input.GetKey(KeyCode.Z) && thrown == false)
        {
            //returns if orb is going out of bounds
            if (magicOrb.transform.position.x < leftLimit.position.x) return;

            magicOrb.transform.position = new Vector3(magicOrb.transform.position.x - magicOrbSpeed,
                magicOrb.transform.position.y, magicOrb.transform.position.z);
            flying = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            thrown = !thrown;
        }
    }
}
