using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

    public static GameEvents instance;

    public delegate void PlayerDelegate(Vector2 position);
    public event PlayerDelegate OnPlayerDeath;

    public delegate void ParameterLessDelegate();
    public event ParameterLessDelegate OnGameStart, OnScoreAdd;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerDied(Vector2 position)
    {
        if (OnPlayerDeath != null)
            OnPlayerDeath(position);
    }

    public void Gamestart()
    {
        if (OnGameStart != null)
            OnGameStart();
    }

    public void ScoreAdd()
    {
        if (OnScoreAdd != null)
            OnScoreAdd();
    }
}
