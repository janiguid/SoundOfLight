using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScroll : MonoBehaviour
{

    public float speed;
    public float timer;
    public bool canMove;
    public float startX;
    // Use this for initialization
    void Start()
    {
        canMove = false;
        timer = 0;
        gamePause();
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == false)
        {
            gamePause();
        }
        if(startX - transform.position.x >= 8)
        {
            canMove = false;
            gamePause();
        }
        if (canMove)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
    }

    void gamePause()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            canMove = true;
            timer = 0;
            startX = transform.position.x;
        }
    }
}
