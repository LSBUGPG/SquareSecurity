using UnityEngine;

public class PauseScript : MonoBehaviour {
    public bool gamePaused;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            gamePaused = !gamePaused;
            if (gamePaused == true) {
                Time.timeScale = 0F;
                //Time.fixedDeltaTime = 0F; //fixed delta time REALLY screws with the NavMesh
            } else {
                Time.timeScale = 1F;
                //Time.fixedDeltaTime = 1F;
            }
        }

    }
}