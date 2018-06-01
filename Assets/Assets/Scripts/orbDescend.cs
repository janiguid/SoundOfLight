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

    // Use this for initialization
    void Start () {
        transform.position = startLoc.position;
        arisen = false;
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position == endLoc.position && arisen != true)
        {
            anim.Play("LyteArise");
            audio.Stop();
            arisen = true;
            myAudio.Play();
        }
        transform.position = Vector3.MoveTowards(transform.position, endLoc.position, speed);

	}
}
