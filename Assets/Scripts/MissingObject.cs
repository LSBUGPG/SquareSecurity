using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MissingObject : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			Camera C = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
			Ray ray = C.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == gameObject) {
					transform.parent.SendMessage ("GainLife");
					Destroy (gameObject);
					print ("Life Up!");
				}
			}
		}
	}
}
