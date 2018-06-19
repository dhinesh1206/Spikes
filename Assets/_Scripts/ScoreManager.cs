using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score;
    public Text scoreText,HighScoreText;

    private void OnEnable()
    {
        GameEvents.instance.OnScoreAdd += On_ScoreAdd;
        GameEvents.instance.OnGameStart += On_GameStart;
        GameEvents.instance.OnPlayerDeath += On_PlayerDeath;
    }

   private void OnDisable()
    {
        GameEvents.instance.OnScoreAdd -= On_ScoreAdd;
        GameEvents.instance.OnGameStart -= On_GameStart;
        GameEvents.instance.OnPlayerDeath -= On_PlayerDeath;
    }

    private void On_GameStart()
    {
        score = 0;
        scoreText.text = "Score :" + score.ToString();
    }

    private void On_PlayerDeath(Vector2 position)
    {
        int HighScore = PlayerPrefs.GetInt("HighScore");
        if (HighScore != null)
        {
            if (score > HighScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }

    private void On_ScoreAdd()
    {
        score += 1;
        scoreText.text = "Score :"+score.ToString();
    }
}
