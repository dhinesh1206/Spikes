using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRingController : MonoBehaviour {

    public static EnemyRingController instance;
    public GameObject enemyCircle;
    public float maxValue, minValue,timeofMovement;
    public Ease easetype;
    public int EnemyCount, index, score;
    public GameObject[] spikes;
    public List<int> indextoActivate;

    private void OnEnable()
    {
        GameEvents.instance.OnPlayerDeath += On_PlayerDeath;
        GameEvents.instance.OnGameStart += On_GameStart;
        GameEvents.instance.OnScoreAdd += On_ScoreAdd;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnPlayerDeath -= On_PlayerDeath;
        GameEvents.instance.OnGameStart -= On_GameStart;
    }

    private void On_GameStart()
    {
        indextoActivate.Clear();
        enemyCircle.transform.DOScale(maxValue, timeofMovement).SetEase(easetype);
    }


    private void On_ScoreAdd()
    {
        score ++;
        switch (score)
        {
            case 0:
                EnemyCount = 3;
                break;
            case 3:
                EnemyCount = 5;
                break;
            case 5:
                EnemyCount = 8;
                break;
            case 8:
                EnemyCount = 10;
                break;
            case 10:
                EnemyCount = 15;
                break;
            default:
                break;
        }
    }


    private void On_PlayerDeath(Vector2 position)
    {
        score = 0;
        StartCoroutine(turnOnSpikes());
    }

    IEnumerator turnOnSpikes()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject spike in spikes)
        {
            spike.SetActive(true);
        }
        EnemyCount = 3;
    }


    private void Awake()
    {
        instance = this;
    }

    public void EnemyMoveOut()
    {
        indextoActivate.Clear();
        enemyCircle.transform.DOScale(maxValue, timeofMovement).SetEase(easetype).OnComplete(() =>{
             EnemySpikesChange();
         });
    }

    public void EnemySpikesChange()
    {
        foreach(GameObject spike in spikes)
        {
            spike.SetActive(false);
        }
        TurnOnEnemy();
    }

    public void TurnOnEnemy()
    {
        for(int i=0; i< EnemyCount; i++)
        {
            index = Random.Range(0, spikes.Length);
            while (indextoActivate.Contains(index))
            {
                index = Random.Range(0, spikes.Length);
            }
            indextoActivate.Add(index);
        }

        foreach(int number in indextoActivate)
        {
            spikes[number].SetActive(true);
        }
        EnemyMoveIn();
    }

    public void EnemyMoveIn()
    {
        enemyCircle.transform.DOScale(minValue, timeofMovement).SetEase(easetype);
    }
}
