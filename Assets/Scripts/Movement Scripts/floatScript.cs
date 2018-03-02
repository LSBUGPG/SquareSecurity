using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatScript : MonoBehaviour {

	public float posY = 18f;
	public float posYSpeed = 0.005f;
	//public float ySpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(0, posY, 0);
		posY += posYSpeed;
		if (posY >= 20) {
			posYSpeed = -0.005f;
		}
		if (posY <= 18) {
			posYSpeed = 0.005f;
		}

	}
}
