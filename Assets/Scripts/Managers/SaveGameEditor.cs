using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameEditor : MonoBehaviour {

	void Start()
	{
		SaveGame.data.Load (); //This loads the game
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (10, 100, 100, 30), "Level Gained!")) {
			SaveGame.data.level += 1;
            SaveGame.data.Save();
            print(SaveGame.data.level);
        }
		if (GUI.Button (new Rect (10, 140, 100, 30), "Level Lost!")) {
			SaveGame.data.level -= 1;
            SaveGame.data.Save();
            print(SaveGame.data.level);
        }
		if (GUI.Button (new Rect (10, 180, 100, 30), "Score Gained")) {
			SaveGame.data.score += 1;
		}
		if (GUI.Button (new Rect (10, 220, 100, 30), "Score Lost")) {
			SaveGame.data.score -= 1;
		}
		if (GUI.Button (new Rect (10, 260, 100, 30), "Save")) {
			SaveGame.data.Save (); //This saves the game
		}
		if (GUI.Button (new Rect (10, 300, 100, 30), "Clear")) {
			SaveGame.data.Clear (); //This deletes the game save
		}
}
}
