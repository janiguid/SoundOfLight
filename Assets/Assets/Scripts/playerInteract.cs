using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour {

    public bool interact;
    public door correspondingDoor;

    public GameObject interactable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X)){
            if (interactable == null) return;
            interactable.GetComponent<lever>().Activate();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (interactable == null) return;
            if(interactable.name == "firstDoor")
            {
                interactable.GetComponent<door>().openFirstDoor();
            }else if(interactable.GetComponent<door>().isActive == true)
            {
                interactable.GetComponent<door>().openFirstDoor();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("blah");


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
