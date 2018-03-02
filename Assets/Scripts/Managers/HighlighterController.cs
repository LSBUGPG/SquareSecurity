using UnityEngine;

public class HighlighterController : MonoBehaviour {
    public AudioSource HighlightedMarkSound; //Audio - public AudioSource (What you want to name it)
    public AudioSource ClickSound; //Audio - public AudioSource (What you want to name it)

    void Update() {
        Camera C = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Ray ray = C.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
		if (Physics.Raycast(ray, out hit) && Time.timeScale >= 0.2f) {
            if (hit.rigidbody != null && hit.rigidbody.tag.Equals("Shopper")) {
                if (Input.GetMouseButtonDown(0)) {
                    ArrestShopper(hit.rigidbody);
                    ClickSound.Play(); //Audio - Name of Audio source.
                    return;
                } else if (Input.GetMouseButtonDown(1)) {
                    HighlightShopper(hit.rigidbody);
                    HighlightedMarkSound.Play(); //Audio - Name of Audio source.
                    return;
                }
            }
        }
    }

    private void ArrestShopper(Rigidbody input) {
        var shopper = input.GetComponent<Shopper>();
        shopper.HightlightIcon.SetActive(false);
        shopper.Darken(false);
        if (shopper.IsSuspicious) {
            shopper.Arrest();
        } else {
            shopper.SuspiciousIcon.SetActive(true);
            shopper.IsSuspicious = true;
        }
        return;
    }

    private void HighlightShopper(Rigidbody input) {
        var shopper = input.GetComponent<Shopper>();
        shopper.SuspiciousIcon.SetActive(false);
        shopper.IsSuspicious = false;
        if (shopper.Highlighted) {
            shopper.Darken(false);
            shopper.HightlightIcon.SetActive(false);
        } else {
            shopper.Darken(true);
            shopper.HightlightIcon.SetActive(true);
        }

        shopper.Highlighted = !shopper.Highlighted;
        return;
    }
}