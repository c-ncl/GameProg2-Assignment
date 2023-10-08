using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore();
    }


    public void OnGameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnGameRestart()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.RestartScore();
    }

    public void OnGameStop()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.RestartScore();
    }

}
