using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FpsInGame : MonoBehaviour {
	float deltaTime = 0.0f;
	public Text fpsCounter;

	void Start()
	{
		InvokeRepeating("FpsTimeCounter", 0f, 0.1f);
	}


	void Update() {
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	void FpsTimeCounter()
	{
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		int fpsRoundedUp = Mathf.CeilToInt(fps);
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		fpsCounter.text = "FPS: " + fpsRoundedUp;
		//deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	void OnGUI() {
		//float msec = deltaTime * 1000.0f;
		//float fps = 1.0f / deltaTime;
		//int fpsRoundedUp = Mathf.CeilToInt(fps);
		//string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		//fpsCounter.text = "FPS: " + fpsRoundedUp;
	}
}