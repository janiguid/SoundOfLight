using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDetector : MonoBehaviour {

    //If the collider under the player's feet comes in contact
    //with a platform tagged as ground, isGrounded is set to 
    //true
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            GetComponentInParent<playerMovement>().isGrounded = true;
        }
    }



}
