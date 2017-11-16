using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {

	public int Camlife = 3;
    public UnityEngine.UI.Text LifeText;
    public AudioSource LostItemSound; //Audio - public AudioSource (What you want to name it)

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        LifeText.text = "Lives Left: " + Camlife + "/3";

      //  if (Input.GetKeyDown(KeyCode.V) && Camlife > 0) {
           // --Camlife; //Cheatcode to lose life
		//}
	//	if (Input.GetKeyDown(KeyCode.B) && Camlife < 3) {
           // ++Camlife; //Cheatcode to gain life
     //   }
        if (Camlife < 1) {
            Debug.Log("Game Over");
            Application.LoadLevel("Lose Screen");
        }
	}

	void GainLife()
	{
		if (Camlife < 3) {
        Camlife = Camlife + 1;
        LostItemSound.Play(); //Audio - Name of Audio source.
        }

	}
}
