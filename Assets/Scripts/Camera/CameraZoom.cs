using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

public class CameraZoom : MonoBehaviour {

	int	zoom = 60;
	int normal = 60;
	public float smooth = 0.1f;
	float zoomVelocity = 0f;
	float turnSpeedVelocity = 0f;

	FreeLookCam freeLookCam;


	private bool isZoomed = true;
	// Use this for initialization
	void Start () {
		freeLookCam = GetComponentInParent<FreeLookCam> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom < 60 && Time.timeScale >= 0.2f) {
			zoom = zoom + 10;
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom > 10 && Time.timeScale >= 0.2f) {
			zoom = zoom - 10;
		}

		if (Input.GetKeyDown(KeyCode.L)) {
			isZoomed = !isZoomed;
		}

		if (isZoomed) 
		{
			GetComponent<Camera> ().fieldOfView = Mathf.SmoothDamp (GetComponent<Camera> ().fieldOfView, zoom, ref zoomVelocity, smooth);
			freeLookCam.m_TurnSpeed = Mathf.SmoothDamp (freeLookCam.m_TurnSpeed, Mathf.Lerp(0.5f, 1.5f, Mathf.InverseLerp(10, 60, zoom)), ref turnSpeedVelocity, smooth);
		}

		else 
		{
			GetComponent<Camera> ().fieldOfView = Mathf.SmoothDamp (GetComponent<Camera> ().fieldOfView, normal, ref zoomVelocity, smooth);	
			freeLookCam.m_TurnSpeed = Mathf.SmoothDamp (freeLookCam.m_TurnSpeed, 1.5f, ref turnSpeedVelocity, smooth);
		}
	}
}