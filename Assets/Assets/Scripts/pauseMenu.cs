using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {
    // pause menu variables
    public string mainMenu;
    public bool isPaused;
    public bool isDown;
    public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {
        isDown = false;
	}
	
	// Update is called once per frame
	void Update () {

        // checks if player pressed pause or not
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
        // toggles pause when player presses Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isPaused = !isPaused;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isDown)
        {
            isDown = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isDown)
        {
            isDown = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isDown)
            {
                SceneManager.LoadScene(mainMenu);
            }
            else
            {
                Resume();
            }
        }

    }

    public void Resume()
    {
        isPaused = false;
    }

}
