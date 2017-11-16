using System;
using UnityEngine;
using System.Collections;

public class HighlighterController : MonoBehaviour
{
    public AudioSource HighlightedMarkSound; //Audio - public AudioSource (What you want to name it)
    public AudioSource ClickSound; //Audio - public AudioSource (What you want to name it)

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse 0");
            Camera C = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Ray ray = C.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
				if (hit.rigidbody != null && hit.rigidbody.tag == "Shopper") {
                    Glow(hit.rigidbody);
                    ClickSound.Play(); //Audio - Name of Audio source.
                    return;
				}
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse 1");
            Camera C = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Ray ray = C.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null && hit.rigidbody.tag == "Shopper") {
                    Mark(hit.rigidbody);
                    HighlightedMarkSound.Play(); //Audio - Name of Audio source.
                    return;
                    

                }
            }
        }
    }

    private void Glow(Rigidbody input)
    {
        var shopper = input.GetComponent<Shopper>();
        if (shopper.Highlighted == false)
        {
            input.transform.Find("Glow").gameObject.SetActive(true);
			input.transform.Find ("Marked").gameObject.SetActive (false);
        }

        if (shopper.IsNotSusp == false && shopper.Highlighted)
        {
            shopper.Arrest();
        }
        shopper.Highlighted = true;
        return;
    }

    private void Mark(Rigidbody input)
    {
        var shopper = input.GetComponent<Shopper>();
        if (shopper.IsNotSusp)
        {
            shopper.IsNotSusp = false;
            input.transform.Find("Glow").gameObject.SetActive(false);
            input.transform.Find("Marked").gameObject.SetActive(false);
        }
        else
        {
            input.transform.Find("Glow").gameObject.SetActive(false);
            input.transform.Find("Marked").gameObject.SetActive(true);
            shopper.IsNotSusp = true;
            shopper.Highlighted = false;
        }
        return;
    }
}