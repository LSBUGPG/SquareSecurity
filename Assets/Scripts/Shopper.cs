using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shopper : MonoBehaviour {
    //public AudioSource AnnouncementSound; //Audio - public AudioSource (What you want to name it)
    public bool IsCriminal, IsNotSusp, Highlighted;
    public void Arrest () {
        if (IsCriminal)
        {
            Debug.Log("The criminal was found.");
            var cm = GameObject.Find("CriminalManager").GetComponent<CriminalManager>();
            var js = GameObject.Find("JailSpot" + (3 - cm.AmountOfCriminalsFound));
            this.gameObject.transform.position = js.transform.position;
            js.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = cm.names[Random.Range(0, cm.names.Count)];
            js.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = cm.arrestReasons[Random.Range(0, cm.arrestReasons.Count)];
            cm.AmountOfCriminalsFound++;
            //AnnouncementSound.Play(); //Audio - Name of Audio source.

            this.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            this.GetComponent<NavigatorFollow>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
            this.transform.Find("Glow").gameObject.SetActive(false);
            this.transform.Find("Marked").gameObject.SetActive(false);
            this.transform.SetParent(null);
            cm.CriminalsLeft();
        } else{
            //. Debug.Log("Wrong.");
            //Sound.Play(); //Audio - Name of Audio source.
            GameObject.Find("LifeManager").GetComponent<LifeController>().Camlife--;
        }
    }
}
