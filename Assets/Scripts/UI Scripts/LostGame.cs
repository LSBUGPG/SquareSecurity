using UnityEngine;
using System.Collections;

public class LostGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Application.LoadLevel("Lose Screen");
    }
}
