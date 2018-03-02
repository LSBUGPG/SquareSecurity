using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterJacobScript : MonoBehaviour {

    public Animator animator;
    public float desiredSpeed = 2;

    // Use this for initialization
    void Start () {

        

    animator.speed = desiredSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
