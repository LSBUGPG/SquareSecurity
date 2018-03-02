using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraIndicator : MonoBehaviour {

	public Color theNewColour = new Color(0.1f, 0.3f, 0.4f);
	public KeyCode key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(key) && Time.timeScale >= 0.2f) {
			print("Colour Flash!");
			GetComponent<Image> ().color = theNewColour;
			transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		} else {
            GetComponent<Image>().color = Color.white;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
