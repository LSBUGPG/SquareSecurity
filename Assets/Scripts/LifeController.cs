using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {

	public int Camlife = 3;
    public UnityEngine.UI.Text LifeText;
    public AudioSource LostItemSound; //Audio - public AudioSource (What you want to name it)
    public AudioSource WrongPersonSound; //Audio - public AudioSource (What you want to name it)
    public GameObject stars;
	public int lostItems = 0;

    // Use this for initialization
    void Start () {
		stars.BroadcastMessage ("UpdateLives", Camlife);
	}
	
	// Update is called once per frame
	void Update () {
        //LifeText.text = Camlife + "/3";

       // if (Input.GetKeyDown(KeyCode.V) && Camlife > 0) {
		//	stars.BroadcastMessage ("UpdateLives", Camlife);
        //    --Camlife; //Cheatcode to lose life
		//}
		//if (Input.GetKeyDown(KeyCode.B) && Camlife < 5) {
		//	stars.BroadcastMessage ("UpdateLives", Camlife);
        //    ++Camlife; //Cheatcode to gain life
       // }
        if (Camlife < 1) {
            Debug.Log("Game Over");
            Application.LoadLevel("Lose Screen");
        }
	}

	void GainLife()
	{
        LostItemSound.Play(); //Audio - Name of Audio source.
		lostItems += 1;
		if (lostItems == 5) {
			Camlife = Camlife + 1;
			stars.BroadcastMessage ("UpdateLives", Camlife);
			//LostItemSound.Play(); //Audio - Name of Audio source. This is played once all the objects have been found
		}
	}

	public void LoseLife()
	{
		Camlife--;
		stars.BroadcastMessage ("UpdateLives", Camlife);
        WrongPersonSound.Play(); //Audio - Name of Audio source.
    }

	public void TimeBonus()
	{
		Camlife += 1;
		stars.BroadcastMessage ("UpdateLives", Camlife);
		print ("TIME BONUS!");
	}
}
