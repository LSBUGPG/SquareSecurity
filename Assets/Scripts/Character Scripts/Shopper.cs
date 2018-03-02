using UnityEngine;

public class Shopper : MonoBehaviour {
    //public AudioSource AnnouncementSound; //Audio - public AudioSource (What you want to name it)
    public bool IsCriminal, Highlighted;
    public bool IsSuspicious = false;
    public GameObject SuspiciousIcon, HightlightIcon;

    public void Start() {
        SuspiciousIcon = transform.Find("SuspiciousIcon").gameObject;
        HightlightIcon = transform.Find("HighlightIcon").gameObject;
    }

    public void Arrest() {
        if (IsCriminal) {
            Debug.Log("The criminal was found.");

            var criminalManager = GameObject.Find("CriminalManager").GetComponent<CriminalManager>();
            criminalManager.AmountOfCriminalsFound++;

            var jailSpot = GameObject.Find("JailSpot_" + criminalManager.AmountOfCriminalsFound);

            this.gameObject.transform.position = jailSpot.transform.position;
            jailSpot.GetComponent<JailSpot>().NameText.text = this.GetComponent<BlockPersonGen>().BlockPersonName;
            jailSpot.GetComponent<JailSpot>().CrimeText.text = this.GetComponent<BlockPersonGen>().Crime;

           
            //AnnouncementSound.Play(); //Audio - Name of Audio source.

            this.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            this.GetComponent<NavigatorFollow>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
            SuspiciousIcon.SetActive(false);
            HightlightIcon.SetActive(false);
            this.Darken(false);
            this.transform.SetParent(null);
            
            criminalManager.CriminalsLeft();
        } else {
            //. Debug.Log("Wrong.");
            //Sound.Play(); //Audio - Name of Audio source.
            GameObject.Find("LifeManager").GetComponent<LifeController>().LoseLife();
        }
    }

    public void Darken(bool apply)
    {
        foreach (var colour in GetComponentsInChildren<SetColour>())
        {
            colour.DarkenColour(apply);
        }
    }
}
