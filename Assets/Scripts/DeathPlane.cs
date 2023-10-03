using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //Restart the level when I hit the trigger
        if(other.tag == "Player")
        {
            // Active scene not into build settings yet
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
