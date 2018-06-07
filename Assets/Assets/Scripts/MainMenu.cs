using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int indicator;
    public string play;
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
            SceneManager.LoadScene(play);
        }

        if (Input.GetKeyDown(KeyCode.Return) && indicator == 2) //Help
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Return) && indicator == 3) //Credits
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Return) && indicator == 4) //Quit
        {
            
        }




    }
}
