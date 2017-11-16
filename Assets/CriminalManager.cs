using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CriminalManager : MonoBehaviour {

    public List<string> arrestReasons = new List<string>();
    public List<string> names = new List<string>();
    public GameObject CriminalDebug;
    public GameObject JailCamera;
    public GameObject TimeManager;
    public int AmountOfCriminalsFound;
    public Transform InfoPanel;
    public Transform ExitButtons;
    public Transform People;
    public Text CriminalsLeftText;
    public AudioSource LevelCompleteSound; //Audio - public AudioSource (What you want to name it)
    public AudioSource HintSound; //Audio - public AudioSource (What you want to name it)
    public AudioSource AnnouncementSound; //Audio - public AudioSource (What you want to name it)
    private bool newHint;
    public void Start() {
        JailCamera.SetActive(false);
    }
    private CriminalManager() {
        arrestReasons.Add("Stealing a birthday balloon");
        arrestReasons.Add("Slapping a 7 year old girl");
        arrestReasons.Add("Godawful dancing");
        arrestReasons.Add("Breaking a pinkie promise");
        arrestReasons.Add("Putting mayo on hotdogs");
        arrestReasons.Add("Being so damn beatiful");
        arrestReasons.Add("Calling me mean names");
        arrestReasons.Add("Places toilet paper under");
        arrestReasons.Add("Tried to mess with Lewis Johnson");

        names.Add("Lewis Johnson");
        names.Add("Siobhan Thomas");
        names.Add("Carlos Evans-Goody");
        names.Add("Joshua Child");
        names.Add("Karl Alexander");
        names.Add("Alan Teacherman");
        names.Add("Kevin Sosa");
        names.Add("Charlie Adams");
        names.Add("Murray Illman");
        names.Add("John Thomas");
        names.Add("Thomas Johnson");
        names.Add("Jamie Hagen");
        names.Add("Tobias Person");
        names.Add("Jack Gileas");
        names.Add("Hayden Glasses");
        names.Add("Amy Johnson");
        names.Add("Jenny Katie");
        names.Add("Sarah Illman");
        names.Add("Ellie Child");
        names.Add("Polly Vonfredrick");
        names.Add("Lisa Sosa");
        names.Add("Lily Flowers");
        names.Add("Katie Jennifer");
        names.Add("Francine Potter");
        names.Add("Jane Potter");
    }


    public void CriminalsLeft() {
        if (AmountOfCriminalsFound < 3) {
            CriminalsLeftText.text = string.Format("Criminals remaining: {0}", (3 - AmountOfCriminalsFound));
            InfoPanel.Find("HatText").GetComponent<Text>().enabled = false;
            InfoPanel.Find("GlassesText").GetComponent<Text>().enabled = false;
            InfoPanel.Find("AccessoryText").GetComponent<Text>().enabled = false;
            InfoPanel.Find("HairText").GetComponent<Text>().enabled = false;
			InfoPanel.Find("FacialHairText").GetComponent<Text>().enabled = false;
			InfoPanel.Find("ShirtText").GetComponent<Text>().enabled = false;
            ActualTime = 180f;
            ClearAllGlows();
            GetCriminal();

        } else {
            //Win Code
            CriminalsLeftText.text = string.Format("No criminals left to catch.");
            GameObject.Find("CameraManager").GetComponent<CameraController>().enabled = false;
            LevelCompleteSound.Play(); //Audio - Name of Audio source.

            GameObject.Find("Hitmarker").GetComponent<Animation>().Play();
            GameObject.Find("CriminalPanel").GetComponent<Animation>().Play();
            GameObject.Find("CrimLeftText").GetComponent<Animation>().Play();
            
            TimeManager.GetComponent<SlowMo>().enabled = false;
            TimeManager.GetComponent<PauseScript>().enabled = false;
            TimeManager.GetComponent<Timer>().enabled = false;

            InfoPanel.gameObject.SetActive(false);
            ExitButtons.gameObject.SetActive(true);
            JailCamera.SetActive(true);
            UnityEngine.Debug.Log("Victory");
            Invoke("GameOver", 1.5f);
        }
    }

    public void FinishedGame() {
       UnityEngine.Debug.Log("Restart");
        Application.LoadLevel("Menu Screen");
    }

    public void GameOver() {
        Time.timeScale = 0f;
    }
    public float ActualTime = 180f;

    private void ClearAllGlows() {
        for (int i = 0; i < People.childCount; i++) {
            var child = People.GetChild(i);
            child.transform.Find("Glow").gameObject.SetActive(false);
            child.transform.Find("Marked").gameObject.SetActive(false);
            child.GetComponent<Shopper>().IsNotSusp = false;
            child.GetComponent<Shopper>().Highlighted = false;
        }
    }
    
    private void GetCriminal() {
        //Find and pick a random criminal
        AnnouncementSound.Play(); //Audio - Name of Audio source.
        Time.timeScale = 1f;
        var people = GameObject.Find("People");
        var randomCriminal = people.transform.GetChild(UnityEngine.Random.Range(0, people.transform.childCount));
        randomCriminal.GetComponent<Shopper>().IsCriminal = true;
        CriminalDebug = randomCriminal.gameObject;
        var blockPerson = randomCriminal.GetComponent<BlockPersonGen>();

        InfoPanel.Find("SkinText").GetComponent<Text>().text = "The person has " + blockPerson._skinList[blockPerson.theChosenSkin].name + " skin.";

        if (blockPerson.hasHat) {
            InfoPanel.Find("HatText").GetComponent<Text>().text = "The person is wearing a " + blockPerson._hatsList[blockPerson.theChosenHat].name + ".";
        } else {
            InfoPanel.Find("HatText").GetComponent<Text>().text = "The person is not wearing a hat.";
        }

        if (blockPerson.hasHair) {
            InfoPanel.Find("HairText").GetComponent<Text>().text = "The person has " + blockPerson._hairList[blockPerson.theChosenHair].name + "hair.";
        } else {
            InfoPanel.Find("HairText").GetComponent<Text>().text = "The person does not have any hair.";
        }

        if (blockPerson.hasGlasses) {
            InfoPanel.Find("GlassesText").GetComponent<Text>().text = "The person is wearing " + blockPerson._glassesList[blockPerson.theChosenGlasses].name + ".";
        } else {
            InfoPanel.Find("GlassesText").GetComponent<Text>().text = "The person is not wearing glasses.";
        }

        if (blockPerson.hasFacialHair) {
            InfoPanel.Find("FacialHairText").GetComponent<Text>().text = "The person has a" + blockPerson._facialHairList[blockPerson.theChosenHair].name + ".";
        } else {
            InfoPanel.Find("FacialHairText").GetComponent<Text>().text = "The person does not have any facial hair.";
        }

        if (blockPerson.hasAccessory) {
            InfoPanel.Find("AccessoryText").GetComponent<Text>().text = "The person is wearing a " + blockPerson._accessoryList[blockPerson.theChosenAccessory].name + ".";
        } else {
            InfoPanel.Find("AccessoryText").GetComponent<Text>().text = "The person is not wearing any accessories.";
        }

        if (blockPerson.hasShirt) {
            InfoPanel.Find("ShirtText").GetComponent<Text>().text = "The person is wearing a shirt." + blockPerson._shirtList[blockPerson.theChosenShirt].name + ".";
        } else {
            InfoPanel.Find("ShirtText").GetComponent<Text>().text = "The person is not wearing a shirt.";
        }
    }

    private void Update() {
        ActualTime -= Time.deltaTime;
        if (ActualTime < (180 - 5)) {
            InfoPanel.Find("HatText").GetComponent<Text>().enabled = true;
            //HintSound.Play(); //Audio - Name of Audio source.
        }
        if (ActualTime < (180 - 10)) {
            InfoPanel.Find("HairText").GetComponent<Text>().enabled = true;
        }
        if (ActualTime < (180 - 15)) {
            InfoPanel.Find("GlassesText").GetComponent<Text>().enabled = true;
        }
        if (ActualTime < (180 - 20)) {
            InfoPanel.Find("FacialHairText").GetComponent<Text>().enabled = true;
        }
        if (ActualTime < (180 - 25)) {
            InfoPanel.Find("AccessoryText").GetComponent<Text>().enabled = true;
        }
		if (ActualTime < (180 - 30)) {
			InfoPanel.Find("ShirtText").GetComponent<Text>().enabled = true;
		}
    }
}
