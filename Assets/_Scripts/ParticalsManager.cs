using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalsManager : MonoBehaviour {

    public GameObject deathPartical;

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

    private void On_PlayerDeath(Vector2 position)
    {
        transform.position = position;
        Instantiate(deathPartical, transform);
    }

    private void On_GameStart()
    {
       
    }
}
