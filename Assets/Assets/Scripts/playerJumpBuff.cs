using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpBuff : MonoBehaviour {

    public Rigidbody2D rb2D;
    public float fallJumpMultiplier, lowFallJumpMultiplier, upwardJumpMultiplier;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        fallJumpMultiplier = 1.75f;
        lowFallJumpMultiplier = 2;
        upwardJumpMultiplier = 1.5f;
    }

    void FixedUpdate () {
        //increases the gravity when Lyte is on her way down
        //when player just taps the jump button, it's a 
        //low jump
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
