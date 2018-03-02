using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCameraMesh : MonoBehaviour {

	public GameObject cameraMesh;

	void OnEnable()
	{
		cameraMesh.SetActive (false);
	}

	void OnDisable()
	{
		cameraMesh.SetActive (true);
	}
}
