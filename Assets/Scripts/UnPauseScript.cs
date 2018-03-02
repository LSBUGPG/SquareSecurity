using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPauseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 1f) {
            Time.timeScale = 1f;
            print("Unpaused!");
        }
	}
}
