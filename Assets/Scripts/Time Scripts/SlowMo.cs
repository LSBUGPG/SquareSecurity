using UnityEngine;
using System.Collections;

public class SlowMo : MonoBehaviour {

    public int timeState = 1;

    void Update() {
		if (Input.GetKeyDown(KeyCode.A) && Time.timeScale >= 0.2f && timeState == 1) {
            Time.timeScale = 0.25F;
            timeState = 0;
            //Time.fixedDeltaTime = 0.25F;
        }
		if (Input.GetKeyUp(KeyCode.A) && Time.timeScale >= 0.2f) {
            Time.timeScale = 1F;
            timeState = 1;
            //Time.fixedDeltaTime = 1F;
        }
        if (Input.GetKeyDown(KeyCode.D) && Time.timeScale >= 0.2f && timeState == 1)
        {
            Time.timeScale = 3F;
            timeState = 2;
            //Time.fixedDeltaTime = 0.25F;
        }
        if (Input.GetKeyUp(KeyCode.D) && Time.timeScale >= 0.2f)
        {
            Time.timeScale = 1F;
            timeState = 1;
            //Time.fixedDeltaTime = 1F;
        }
    }
}