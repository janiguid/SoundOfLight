using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour {

    public bool isActive = false;
    public door correspondingDoor;

    public void Activate()
    { 
        isActive = !isActive;

        //this connects the lever and door
        correspondingDoor.Activate();
        if (isActive)
        {
            gameObject.GetComponent<Animator>().SetBool("isActive", true);
        }
        else if (isActive == false)
        {
            gameObject.GetComponent<Animator>().SetBool("isActive", false);
        }
    }

}
