﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpBuff : MonoBehaviour {

    public Rigidbody2D rb2D;
    public float fallJumpMultiplier, lowFallJumpMultiplier, upwardJumpMultiplier;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        fallJumpMultiplier = 6f;
        lowFallJumpMultiplier = 2;
        upwardJumpMultiplier = 1.5f;
    }

    void FixedUpdate () {
        if (rb2D.velocity.y < 0)
        {
            rb2D.gravityScale = fallJumpMultiplier;
        }
        else if (rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.gravityScale = lowFallJumpMultiplier;
        }
        else
        {
            rb2D.gravityScale = 1;
        }
    }
}
