using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour {

    public bool interact;
    public door correspondingDoor;

    public GameObject interactable;

	
	// Update is called once per frame
	void Update () {
        
        //if player presses interact button, activate whatever 
        //interactable object Lyte is near
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (interactable == null) return;
                interactable.GetComponent<lever>().Activate();
            
        }
        
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (interactable == null) return;
            if (interactable.name == "firstDoor")
            {
                interactable.GetComponent<door>().openFirstDoor();
            }
            else if (interactable.GetComponent<door>().isActive == true)
            {
                interactable.GetComponent<door>().openFirstDoor();
            }
            else
            {
                //plays locked sound when player tries to open the door
                //and its not active
                interactable.GetComponent<AudioSource>().Play();
            }
        }
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //*this is unnecessarily redundant
        //ensures Lyte only interacts with levers and doors
        if(collision.tag == "lever")
        {
            interactable = collision.gameObject;
        }else if(collision.name == "firstDoor")
        {
            interactable = collision.gameObject;
        }else if(collision.name == "Door")
        {
            interactable = collision.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
    }
}
