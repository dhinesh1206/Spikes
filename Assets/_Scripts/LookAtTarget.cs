using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
        transform.LookAt(Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
