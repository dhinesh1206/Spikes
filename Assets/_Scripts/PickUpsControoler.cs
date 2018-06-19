using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpsControoler : MonoBehaviour {

    public GameObject pickupPrefabs, parent;
    public List<GameObject> activePickUps;
    public float pickUpActivetime;

    private void OnEnable()
    {
        GameEvents.instance.OnScoreAdd += On_ScoreAdd;
        GameEvents.instance.OnGameStart += On_ScoreAdd;
        GameEvents.instance.OnPlayerDeath += On_PlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnScoreAdd -= On_ScoreAdd;
        GameEvents.instance.OnGameStart -= On_ScoreAdd;
        GameEvents.instance.OnPlayerDeath -= On_PlayerDeath;
    }

    private void On_PlayerDeath(Vector2 position)
    {
        StopAllCoroutines();
        foreach (GameObject obj in activePickUps.ToList())
        {
            activePickUps.Remove(obj);
            Destroy(obj);
        }
    }

    private void On_ScoreAdd()
    {
        StartCoroutine(pickupActivate());
        foreach (GameObject obj in activePickUps.ToList())
        {
            activePickUps.Remove(obj);
        }
    }

    IEnumerator pickupActivate()
    {
        yield return new WaitForSeconds(pickUpActivetime);
        GameObject pickup = Instantiate(pickupPrefabs, parent.transform);
        pickup.transform.position = new Vector2(Random.Range(2.2f, -2.2f), Random.Range(-2.2f, 2.2f));
        activePickUps.Add(pickup);
    }
}
