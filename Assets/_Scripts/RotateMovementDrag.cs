using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovementDrag : MonoBehaviour {
    public float threshold;
    public float speed;
    public bool playing;

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
        playing = true;
    }

    private void On_PlayerDeath(Vector2 position)
    {
        playing = false;
    }

    void Update () {

		if (Input.GetMouseButton(0) && playing)
		{
			if (Mathf.Abs(MouseHelper.mouseDelta.x) > threshold)
			{
				transform.Rotate(Vector3.forward * MouseHelper.mouseDelta.x * speed * Time.deltaTime);	
			}
		}
	}
}
