using UnityEngine;
using System.Collections;

public class SlowMo : MonoBehaviour {

    void Update() {
		if (Input.GetKeyDown(KeyCode.E) && Time.timeScale >= 0.2f) {
            Time.timeScale = 0.25F;
            //Time.fixedDeltaTime = 0.25F;
        }
		if (Input.GetKeyUp(KeyCode.E) && Time.timeScale >= 0.2f) {
            Time.timeScale = 1F;
            //Time.fixedDeltaTime = 1F;
        }

    }
}