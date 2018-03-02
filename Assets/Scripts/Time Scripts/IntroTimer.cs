using UnityEngine;
using System.Collections;

public class IntroTimer : MonoBehaviour {

    public float TotalTime = 3f;
    public float ActualTime = 3f;
    //public UnityEvent OnTimerExpired;

    // Use this for initialization
    void Start() {
        ActualTime = TotalTime;
    }

    // Update is called once per frame
    void Update() {
        ActualTime -= Time.deltaTime;

        if (ActualTime <= 0) {
            Application.LoadLevel("Menu Screen");
            //OnTimerExpired.Invoke ();
        }
    }
}