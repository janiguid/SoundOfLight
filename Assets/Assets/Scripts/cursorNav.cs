using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorNav : MonoBehaviour {

    // cursor manipulation variables 
    public bool isDown;
    public float yOffset = 10f;

    // Use this for initialization
    void Start () {
        isDown = false;
	}
	
	// Update is called once per frame
	void Update () {
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
}
