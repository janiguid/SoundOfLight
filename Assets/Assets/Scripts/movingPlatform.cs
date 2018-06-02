using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

    public Transform targetLocation;
    public Transform initialLocation;
    public float platformSpeed;
    public Transform temp;
    public bool isHorizontal;
    public bool isActive;
    

	// Update is called once per frame
	void Update () {
        if (!isActive) return;
		if(transform.position != targetLocation.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation.position, platformSpeed);
            //Debug.Log("Moving towards " + targetLocation.position.x);
        }else if(isHorizontal && transform.position.x >= targetLocation.position.x)
        {
            //make current location equal to target location
            //set target location to initial location
            Swap();
        }else if(!isHorizontal && transform.position.y >= targetLocation.position.y)
        {
            Debug.Log("Here");
            Swap();
        }
	}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //setting the player's transform as a child of the 
    //    //moving platform makes the player move with the 
    //    //platform
    //    if (collision.tag == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(transform);
    //    }


    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(null);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision collision)
    {
        
    }

    void Swap()
    {
        temp = targetLocation;
        targetLocation = initialLocation;
        initialLocation = temp;

    }

    public void Activate()
    {
        isActive = !isActive;
    }
}
