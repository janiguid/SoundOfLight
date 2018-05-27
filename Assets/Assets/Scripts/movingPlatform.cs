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
    

	// Use this for initialization
	void Start () {
		
	}
	
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

    void Swap()
    {
        temp = targetLocation;
        targetLocation = initialLocation;
        initialLocation = temp;

    }
}
