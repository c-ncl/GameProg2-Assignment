using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuManager : MonoBehaviour
{
    public Text scoreText;


    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore();
    }
}
