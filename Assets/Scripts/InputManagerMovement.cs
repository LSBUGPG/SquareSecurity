using UnityEngine;
using System.Collections;

public class InputManagerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw("Horizontal") > 0) {
			// Move to the right
			transform.Translate (Vector3.right * Time.deltaTime);
		} 
		else if (Input.GetAxisRaw("Horizontal") < 0) {
			// Move to the left
			transform.Translate (Vector3.left * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Vertical") > 0) {
			transform.Translate (Vector3.forward * Time.deltaTime);
		} 
		else if (Input.GetAxisRaw("Vertical") < 0) {
			transform.Translate (Vector3.back * Time.deltaTime);
		}
	}
}