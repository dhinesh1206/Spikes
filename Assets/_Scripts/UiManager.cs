using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

    public GameObject mainScreen, gameOverScreen,gameScreen;
    public float gameoverScreenWaitTime;

    private void OnEnable()
    {
        GameEvents.instance.OnPlayerDeath += On_PlayerDeath;
        GameEvents.instance.OnGameStart += On_GameStart;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnPlayerDeath -= On_PlayerDeath;
        GameEvents.instance.OnGameStart -= On_GameStart;
    }

    private void On_GameStart()
    {
        gameOverScreen.SetActive(false);
        gameScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    private void On_PlayerDeath(Vector2 position)
    {
        StartCoroutine(gameOverScreenDisable());
    }

    IEnumerator gameOverScreenDisable()
    {
        yield return new WaitForSeconds(gameoverScreenWaitTime);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
