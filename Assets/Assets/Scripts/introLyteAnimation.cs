using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introLyteAnimation : MonoBehaviour {

    public Animator anim;
    public AudioSource audio;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    // Use this for initialization
    void Start () {
        anim.Play("LyteSit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void startSong()
    {
        audio.Play();
    }

    void stand()
    {
        anim.Play("LyteIdle");
     
    }
}
