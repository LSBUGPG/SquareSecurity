using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPause : MonoBehaviour {

    public AudioClip musicClip;

	// Use this for initialization
	void Start () {
        //audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0F) {
           // audio.Pause();
        } else {
            //audio.Play();
        }
	}
}
