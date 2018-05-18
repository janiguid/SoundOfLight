using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour {

    public Sprite[] sprite;
    public bool isActive = false;



    public void Activate()
    { 
        isActive = !isActive;
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
