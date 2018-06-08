using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour {

    public bool isActive = false;
    public door correspondingDoor;
    public movingPlatform correspondingPlatform;

    public void Activate()
    { 
        //outer if statements determine which object to activate
        if(correspondingDoor != null)
        {
            isActive = !isActive;
            GetComponent<AudioSource>().Play();

            //this connects the lever and door
            correspondingDoor.Activate();

            //responsible for animation of levers
            if (isActive)
            {
                gameObject.GetComponent<Animator>().SetBool("isActive", true);
            }
            else if (isActive == false)
            {
                gameObject.GetComponent<Animator>().SetBool("isActive", false);
            }
        }else if(correspondingPlatform != null)
        {
            isActive = !isActive;
            GetComponent<AudioSource>().Play();

            //calls activate function in corresponding platform
            correspondingPlatform.Activate();

            //animation of lever
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

}
