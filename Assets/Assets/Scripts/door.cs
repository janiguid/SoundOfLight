using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour {

    public bool isActive = false;
    public bool isUnlocked = false;

    public void Start()
    {
        if(gameObject.name == "firstDoor")
        {
            //gameObject.GetComponent<Animator>().Play("DoorOpen");
            gameObject.GetComponent<Animator>().SetBool("isActive", true);
        }
    }

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

    public void openFirstDoor()
    {
        ////SceneManager.GetActiveScene().buildIndex + 1)
        //if(SceneManager.GetActiveScene().buildIndex == 3)
        //{
        //    Debug.Log("supposed to exit");
        //    SceneManager.LoadScene(0);
        //}
        //else
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
