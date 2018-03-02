using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetHighlights : MonoBehaviour {

    public Transform People;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            for (int i = 0; i < People.childCount; i++) {
                var child = People.GetChild(i);
                child.GetComponent<Shopper>().HightlightIcon.SetActive(false);
                child.GetComponent<Shopper>().SuspiciousIcon.SetActive(false);
                child.GetComponent<Shopper>().IsSuspicious = false;
                child.GetComponent<Shopper>().Highlighted = false;
                child.GetComponent<Shopper>().Darken(false);
            }
        }
    }

	public void HighlightReset () {


	}
}
