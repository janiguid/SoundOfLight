using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int indicator;
    public float xOffset = 100f;
    void Start()
    {
        indicator = 1;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (indicator == 4)
            {
                indicator = 1;
            }
            else
            {
                indicator += 1;         
            }
        
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (indicator == 1)
            {
                indicator = 4;
            }
            else
            {
                indicator -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && indicator == 1) //play
        {
            SceneManager.LoadScene("Intro");
        }

        if (Input.GetKeyDown(KeyCode.C) && indicator == 2) //controls
        {
            SceneManager.LoadScene("controls");
        }

        if (Input.GetKeyDown(KeyCode.C) && indicator == 3) //Credits
        {
            
        }

        if (Input.GetKeyDown(KeyCode.C) && indicator == 4) //Quit
        {
            Application.Quit();
        }




    }
}
