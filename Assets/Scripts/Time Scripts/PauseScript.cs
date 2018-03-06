using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
	
    public bool gamePaused;
	public bool gameStarted;
	public GameObject pauseMenu;
	public GameObject startMenu;
	public GameObject music;
	public GameObject announcementSound;
	public AudioSource AnnouncementSound;
	public int currentLevel;
	//public Image pauseMenu;


	void Awake () {
		gameStarted = false;
		startMenu.SetActive (true);
		//Time.timeScale = 0F;
	}

	void Start(){
		Time.timeScale = 0F;
		Screen.lockCursor = true;
		Cursor.visible = false;
	}

    void Update() {

		if (Input.GetKeyDown(KeyCode.Space) && gameStarted == false) {
			gameStarted = true;
			startMenu.SetActive (false);
			Time.timeScale = 1F;
			music.SetActive (true);
			announcementSound.SetActive (true);
			AnnouncementSound.Play();
			gameObject.GetComponent<MinTimer>().gameHasStarted = true;
		}

		if (Input.GetKeyDown(KeyCode.P) && gameStarted == true) {
            gamePaused = !gamePaused;
            if (gamePaused == true) {
				//Cursor.visible = false;
                Time.timeScale = 0F;
				pauseMenu.SetActive (true);
				//pauseMenu.enabled = true;
                //Time.fixedDeltaTime = 0F; //fixed delta time REALLY screws with the NavMesh
				Screen.lockCursor = false;
            } else {
                Time.timeScale = 1F;
				pauseMenu.SetActive (false);
				Screen.lockCursor = true;
				//Cursor.visible = false;
                //Time.fixedDeltaTime = 1F;
            }
        }
		if (Input.GetKeyDown(KeyCode.R) && Time.timeScale <= 0.2f && gameStarted == true) {
			Application.LoadLevel(currentLevel); //Restarts the current level
		}
		if (Input.GetKeyDown(KeyCode.M) && Time.timeScale <= 0.2f && gameStarted == true) {
			Application.LoadLevel(1); //Quits to the main Menu
		}
    }
}