using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPlatformScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //setting the player's transform as a child of the 
        //moving platform makes the player move with the 
        //platform
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.SetParent(GetComponentInParent<Transform>().transform);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
