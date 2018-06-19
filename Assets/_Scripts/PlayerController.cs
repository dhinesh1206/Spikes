using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float thrust, maxVelocity, score;

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
        GameEvents.instance.OnScoreAdd -= On_ScoreAdd;
    }

    private void On_ScoreAdd()
    {
        score ++;
        if(score == 5)
        {
            thrust += 50;
        }
        else if(score == 10)
        {
            thrust += 50;
        }
        else if(score == 15)
        {
            thrust += 50;
        }
    }

    public void On_GameStart()
    {
        thrust = 150;
        transform.position = Vector3.zero;
        GetComponent<Rigidbody2D>().AddForce(-transform.up * thrust);
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void On_PlayerDeath(Vector2 position)
    {
        score = 0;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Circle")
        {
            EnemyRingController.instance.EnemyMoveOut();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(0.15f,-0.15f),0)  * thrust);
        }
        else if(collision.gameObject.tag =="Enemy")
        {
            GameEvents.instance.PlayerDied(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            GameEvents.instance.ScoreAdd();
            Destroy(collision.gameObject);
        }
    }
}
