using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbDescend : MonoBehaviour {

    public Transform endLoc;
    public Transform startLoc;
    public float speed;
    public Animator anim;
    public bool arisen;
    public AudioSource audio;
    public AudioSource myAudio;

    public Sprite[] sprite;
    public SpriteRenderer spriteRenderer;
    public float timer;
    public int currentIndex;

    // Use this for initialization
    void Start () {
        transform.position = startLoc.position;
        arisen = false;
        myAudio = GetComponent<AudioSource>();
        currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position == endLoc.position && arisen != true)
        {
            anim.Play("LyteArise");
            audio.Stop();
            arisen = true;
            myAudio.Play();
            spriteRenderer.sprite = sprite[currentIndex];
            currentIndex++;
        }
        transform.position = Vector3.MoveTowards(transform.position, endLoc.position, speed);

        if (transform.position == endLoc.position && arisen == true && currentIndex != 4)
        {
            timer += Time.fixedDeltaTime;

            if (timer > 5)
            {
                spriteRenderer.sprite = sprite[currentIndex];
                currentIndex++;
                timer = 0;
            }
        }

    }
}
