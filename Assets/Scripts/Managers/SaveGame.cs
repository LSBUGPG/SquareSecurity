using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour {

	public static SaveGame data;

	public float level;
	public float score;


	public int sceneToLoad;

	 void Awake() {
		if (data == null) {
			DontDestroyOnLoad (gameObject);
			data = this;
		}
		else if (data != this) {
			Destroy (gameObject);
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 30), "Level: " + level); //This displays the health
		GUI.Label (new Rect (10, 40, 150, 30), "Score: " + score); //This displays the Experience
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		Debug.Log (Application.persistentDataPath + "/saveData.dat");
		FileStream file = File.Create (Application.persistentDataPath + "/saveData.dat"); // Words in quote marks is the name of the save file

		PlayerData data = new PlayerData ();
		data.health = level; //This saves the health
		data.experience = score; //This saves the experience

		bf.Serialize (file, data);
		file.Close ();
	}
	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/saveData.dat")) // Words in quote marks is the name of the save file
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.OpenRead(Application.persistentDataPath + "/saveData.dat"); // Words in quote marks is the name of the save file
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();

			level = data.health;
			score = data.experience;
		}
	}
	public void Clear()
	{
		File.Delete (Application.persistentDataPath + "/saveData.dat");
	}
}

[Serializable]
class PlayerData
{
	public float health;
	public float experience;
}