using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPause : MonoBehaviour {

	public int startingPitch = 4;
	public int timeToDecrease = 5;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.pitch = startingPitch;
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0.25f) {
			audioSource.pitch = 0.8f;
		}
		if (Time.timeScale == 1f) {
			audioSource.pitch = 1f;
		}
        if (Time.timeScale == 3f){
            audioSource.pitch = 1.2f;
        }

        if (Time.timeScale == 0f) {
			audioSource.pitch = 0f;
		}
	}
}
