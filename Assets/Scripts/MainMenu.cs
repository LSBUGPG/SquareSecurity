using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StartGame () {
        Application.LoadLevel(2);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void MenuGame() {
        Application.LoadLevel(1);
    }
}
