using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedTrapBehaviour : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.RestartLevelScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
