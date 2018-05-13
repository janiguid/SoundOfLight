using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour {

    public void ExitPlay()
    {
        SceneManager.LoadScene(0);
    }

}
