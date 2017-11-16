using UnityEngine;
using System.Collections;

public class CameraTest : MonoBehaviour {

	public GameObject target;
	public float rotateSpeed = 5f;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0);

		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);

		transform.LookAt(target.transform);
	}
}
