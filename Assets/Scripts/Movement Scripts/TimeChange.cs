using UnityEngine;
using System.Collections;

public class TimeChange : MonoBehaviour {

	// Use this for initialization
	public KeyCode activationKey; //Allows the change of controls from the inspector. - Tobias
	public float timeDiff; //The multiplier which the time scale changes to when activated. - Tobias
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(activationKey)) {
			Time.timeScale = timeDiff; // When the activationKey is pressed it will change the time scale to the value of timeDiff. Normal time is 1. Half speed is 0.5 and double speed is 2. - Tobias
		} else {
			Time.timeScale = 1; //When the button is released, time will return to normal speed. - Tobias
		}
	}
}
