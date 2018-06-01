using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introScroll : MonoBehaviour
{
    public Light lightSource;

    public float speed;
    public float timer;
    public bool canMove;
    public float startX;
    public float difference;
    public float pauseLength;
    public float sceneCounter;
    public float lightDecrementor;

    // Use this for initialization
    void Start()
    {
        canMove = false;
        timer = 0;
        gamePause();
        startX = transform.position.x;
        difference = 8;
        pauseLength = 10;
        lightDecrementor = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(lightSource.range < 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (sceneCounter > 6)
        {
            canMove = false;
            lightSource.range -= 0.01f;
            return;
        }
        //if (sceneCounter == 8) return;

        if (sceneCounter == 0)
        {
            pauseLength = 10;
        }
        else
        {
            pauseLength = 13;
        }


        if(canMove == false)
        {
            gamePause();
        }
        if(startX - transform.position.x >= difference)
        {
            canMove = false;
            gamePause();
        }
        if (canMove && (sceneCounter < 7))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        if(sceneCounter == 3)
        {
            if(lightSource.range > 11)
            {
                lightSource.range -= lightDecrementor;
            }
        }else if(sceneCounter == 4)
        {
            lightDecrementor = 0.005f;
            if(lightSource.range > 10)
            {
                lightSource.range -= lightDecrementor;
            }
        }else if(sceneCounter == 5)
        {
            if(lightSource.range > 9.5)
            {
                lightSource.range -= lightDecrementor;
            }
        }
    }

    void gamePause()
    {
        
        timer += Time.fixedDeltaTime;

        if (timer > pauseLength)
        {
            canMove = true;
            timer = 0;
            startX = transform.position.x;
            sceneCounter++;
        }
    }
}
