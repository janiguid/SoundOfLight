using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public SpriteRenderer[] spriteRendererToFade;
    public Transform pointToBeginTransition;
    public Transform orbPosition;
    Color spriteColor;

    public float fadeOutSpeed;
    public int currentIndex;

	void Start () {
       spriteRenderer = GetComponent<SpriteRenderer>();
       currentIndex = 0;

    }
	
	// Update is called once per frame
	void Update () {
        spriteColor = spriteRenderer.color;

        //to ensure sky doesn't change until apex is reached
        if (orbPosition.position.y <= pointToBeginTransition.position.y) return;
        if(spriteColor.a > 0 && currentIndex != 7)
        {
            //decreases the opacity of the color
            spriteColor.a -= fadeOutSpeed;
            spriteRenderer.color = spriteColor;
        }
        else if(spriteColor.a < 0 && currentIndex != 6)
        {
            //changes which sprite we're dealing with
            currentIndex++;
            spriteRenderer.sprite = spriteRendererToFade[currentIndex].sprite;
            spriteRendererToFade[currentIndex].enabled = false;
            spriteColor.a = 1;
            spriteRenderer.color = spriteColor;
        }        
    }
}
