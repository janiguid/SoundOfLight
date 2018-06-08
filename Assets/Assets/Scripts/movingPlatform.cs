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

        //if platform has not reached destination, keep moving towards it
        //else swap
		if(transform.position != targetLocation.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation.position, platformSpeed);
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
