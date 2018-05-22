using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbFollow : MonoBehaviour {

    public GameObject originalPlace;
    public playerShoot playerShoot;
    public Animator anim;
    public float timer = 0;

	// Use this for initialization
	void Start () {
        originalPlace = GameObject.FindGameObjectWithTag("OrbPlaceholder");
        playerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<playerShoot>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerShoot.thrown == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("calledBack", true);
        }
	}

    void returnToLyte()
    {
        anim.SetBool("calledBack", false);
        transform.position = originalPlace.transform.position;

    }
}
