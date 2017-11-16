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
        if (Input.GetKeyDown(KeyCode.R)) {
            for (int i = 0; i < People.childCount; i++) {
                var child = People.GetChild(i);
                child.transform.Find("Glow").gameObject.SetActive(false);
                child.transform.Find("Marked").gameObject.SetActive(false);
                child.GetComponent<Shopper>().IsNotSusp = false;
                child.GetComponent<Shopper>().Highlighted = false;
            }
        }
    }

	public void HighlightReset () {


	}
}
