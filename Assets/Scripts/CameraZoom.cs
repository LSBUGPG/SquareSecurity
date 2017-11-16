using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	int	zoom = 60;
	int normal = 60;
	float smooth = 5;

	private bool isZoomed = true;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom < 60) {
			zoom = zoom + 10;
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom > 10) {
			zoom = zoom - 10;
		}

		if (Input.GetKeyDown(KeyCode.W)) {
			isZoomed = !isZoomed;
		}

		if (isZoomed) 
		{
			GetComponent<Camera> ().fieldOfView = Mathf.Lerp (GetComponent<Camera> ().fieldOfView, zoom, Time.deltaTime * smooth);
		}

		else 
		{
			GetComponent<Camera> ().fieldOfView = Mathf.Lerp (GetComponent<Camera> ().fieldOfView, normal, Time.deltaTime * smooth);	
		}
	}
}