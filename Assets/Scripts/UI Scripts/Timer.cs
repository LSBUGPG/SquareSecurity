using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float TotalTime = 300f;
    public float ActualTime = 300f;
	public float CountTime = 1f;
    public Text TimeText;

    //public UnityEvent OnTimerExpired;

	// Use this for initialization
	void Start () {
        ActualTime = TotalTime;
	}
	
	// Update is called once per frame
	void Update () {
        ActualTime -= Time.unscaledDeltaTime;
		TimeText.text = "00:" + (int) ActualTime;
        if (ActualTime <= 0)
        {
            Application.LoadLevel("Lose Screen");
            //OnTimerExpired.Invoke ();
        }
	}
}
