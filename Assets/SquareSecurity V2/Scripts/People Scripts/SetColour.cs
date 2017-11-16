using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColour : MonoBehaviour {

	public string type;
	Renderer renderer;

	void Awake()
	{
		renderer = GetComponent<Renderer> ();
	}

	public void ChangeColour(string type, Material material)
	{
		if (this.type == type) {

			renderer.material = material;
		}
	}
}
