using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour {

	public Sprite filled;
	public Sprite empty;
	public int star;
	Image image;

	void Awake()
	{
		image = GetComponent<Image> ();
	}

	void UpdateLives(int lives)
	{
		image.sprite = (lives >= star) ? filled : empty;
	}
}
