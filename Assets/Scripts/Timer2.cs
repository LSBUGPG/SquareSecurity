using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer2 : MonoBehaviour {

	public Text counterText;

	public float seconds, minutes;
	// Use this for initialization
	void Start () {
		counterText = GetComponent<Text>() as Text;
	}

	// Update is called once per frame
	void Update() {
		minutes = (int)(Time.timeSinceLevelLoad/60f);
		seconds = (int)(Time.timeSinceLevelLoad % 60f);
		counterText.text = "00:" + minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}

//Taken from https://www.youtube.com/watch?v=VVZudrLh5EA