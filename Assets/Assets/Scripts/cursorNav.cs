using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorNav : MonoBehaviour {

    // cursor manipulation variables 
    public int indicator = 1;
    public bool vert;
    public bool isDown;
    public float yOffset = 135f;
    public float[] xOffset;

    // Use this for initialization
    void Start () {
        isDown = false;
        xOffset = new float[]{ 0f, -4.93f, -2.15f, 1.48f, 5.02f };
    }

    // Update is called once per frame
    void Update() {
        if (vert)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!isDown)
                {
                    Vector2 position = transform.position;
                    position.y -= yOffset;
                    transform.position = position;
                    isDown = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isDown)
                {
                    Vector2 position = transform.position;
                    position.y += yOffset;
                    transform.position = position;
                    isDown = false;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (indicator == 4)
                {
                    indicator = 1;
                    Vector2 position = transform.position;
                    position.x = xOffset[1];
                    transform.position = position;
                }
                else
                {
                    indicator += 1;
                    Vector2 position = transform.position;
                    position.x = xOffset[indicator];
                    transform.position = position;
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (indicator == 1)
                {
                    indicator = 4;
                    Vector2 position = transform.position;
                    position.x = xOffset[4];
                    transform.position = position;
                }
                else
                {
                    indicator -= 1;
                    Vector2 position = transform.position;
                    position.x = xOffset[indicator];
                    transform.position = position;
                }
            }
        }
    }
}
