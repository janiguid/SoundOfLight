using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class grimReaper : MonoBehaviour {


    //destroy Lyte when she enters the collider and reload scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
