using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public GameObject startMenu;

	void Awake () {
		Time.timeScale = 0F;
		startMenu.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale <= 0f) {
			Time.timeScale = 1f; //Starts the game
		}
	}
}
