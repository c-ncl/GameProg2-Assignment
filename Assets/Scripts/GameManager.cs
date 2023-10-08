using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float Score = 0;
    public float LevelScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void IncrementScore()
    {
        Score += 50;
    }

    public void SetLevelScore(float currScore)
    {
        LevelScore = Score;
    }

    public void RestartLevelScore(){
        Score = LevelScore;
    }

    public void RestartScore()
    {
        Score = 0;
    }

    public float GetScore()
    {
        return Score;
    }
}
