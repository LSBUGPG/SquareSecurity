using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {
	public float HorizontalSpeed = 2.0f;
	public float VerticalSpeed = 2.0f;

	private float RotateX = 0.0f;
	private float RotateY = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		RotateX += HorizontalSpeed * Input.GetAxis("Mouse X");
		RotateY-= VerticalSpeed * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(RotateY, RotateX, 0.0f);
	}
}