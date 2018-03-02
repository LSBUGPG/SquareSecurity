using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinTimer : MonoBehaviour {


	public Text countDownText;
	public float minutes, seconds;
	public float totalTime = 180f;
	public float currentTime = 0f;

	// Use this for initialization
	void Start () {
		currentTime = totalTime;
	}
	
	// Update is called once per frame
	void Update () {
		minutes = (int)(currentTime/60f);
		seconds = (int)(currentTime % 60f); //currentTime replaces Time.time
		countDownText.text = "00:" + minutes.ToString ("00") + ":" + seconds.ToString ("00");
		if (Time.timeScale >= 0.2f) {
			currentTime -= Time.unscaledDeltaTime;
		}
		if (currentTime <= 0)
		{
			Application.LoadLevel("Lose Screen");
			//OnTimerExpired.Invoke ();
		}
		
	} //This is an adaptation of code from the following: www.youtube.com/watch?v=VVZudrLh5EA
}
