using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
	
    public bool gamePaused;
	public GameObject pauseMenu;
	//public Image pauseMenu;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            gamePaused = !gamePaused;
            if (gamePaused == true) {
                Time.timeScale = 0F;
				pauseMenu.SetActive (true);
				//pauseMenu.enabled = true;
                //Time.fixedDeltaTime = 0F; //fixed delta time REALLY screws with the NavMesh
            } else {
                Time.timeScale = 1F;
				pauseMenu.SetActive (false);
				//pauseMenu.enabled = false;
				Cursor.visible = false;
                //Time.fixedDeltaTime = 1F;
            }
        }
		if (Input.GetKeyDown(KeyCode.R) && Time.timeScale <= 0.2f) {
			Application.LoadLevel(2); //Restarts the current level
		}
		if (Input.GetKeyDown(KeyCode.M) && Time.timeScale <= 0.2f) {
			Application.LoadLevel(1); //Quits to the main Menu
		}
    }
}