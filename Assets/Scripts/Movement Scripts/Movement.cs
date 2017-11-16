using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody rb;
	public int speed;
	float posY;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //Finds the attached rigidbody of the object - Tobias
		posY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		posY = transform.position.y;
		float Horz = Input.GetAxis ("Horizontal"); // Creates a float that uses the axis for the Horizontal input (Left and right arrows, A and D, and xbox controllers analog stick) - Tobias
		float Vert = Input.GetAxis ("Vertical"); // The same as the previous line but with a different float and input. - Tobias

		rb.MovePosition(transform.position + (transform.right * Horz * speed * Time.deltaTime) + (transform.forward * Vert * speed * Time.deltaTime));  //Moves the rigidbody body so that collision still occurs. It moves using the axis input. The input ranges from -1 to 1. - Tobias
	}
}
