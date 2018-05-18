using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour {

    public bool interact;

    public GameObject interactable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X)){
            interactable.GetComponent<lever>().Activate();
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("blah");


            if(collision.tag == "lever")
            {
                interactable = collision.gameObject;
            }
    }

}
