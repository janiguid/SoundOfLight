using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    int indicator = 1;

    private void update()
    {

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (indicator == 4)
                indicator = 1;
            else
                indicator += 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (indicator == 1)
                indicator = 4;
            else
                indicator -= 1;
        }

        if (Input.GetKeyDown(KeyCode.Return) && indicator == 1) //play
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
