using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriminalManager : MonoBehaviour {


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
	public int totalCriminalsLevel;
    public GameObject[] inGameUI;
    private bool newHint;

    public void Start() {
        JailCamera.SetActive(false);
    }

    public void CriminalsLeft() {
		if (AmountOfCriminalsFound < totalCriminalsLevel) {
			CriminalsLeftText.text = string.Format("{0}", (AmountOfCriminalsFound) + "/" + (totalCriminalsLevel));
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
            //CriminalsLeftText.text = string.Format("No criminals left to catch.");
            GameObject.Find("CameraManager").GetComponent<CameraController>().enabled = false;
            LevelCompleteSound.Play(); //Audio - Name of Audio source.
			if (levelTime >= 300f) {
				print (levelTime);
				GameObject.Find("LifeManager").GetComponent<LifeController>().TimeBonus();
			}
            TimeManager.GetComponent<SlowMo>().enabled = false;
            TimeManager.GetComponent<PauseScript>().enabled = false;
            TimeManager.GetComponent<Timer>().enabled = false;

            if (SaveGame.data.level == 0) {
                SaveGame.data.level += 1;
                SaveGame.data.Save();
            }

            InfoPanel.gameObject.SetActive(false);
            ExitButtons.gameObject.SetActive(true);
			//Bonus star

//			GameObject.Find ("TimeManager").GetComponent<MinTimer> ().currentTime;
//			currentTime == bonusTime
//			if (currentTime >= 300) {
//				GameObject.Find("LifeManager").GetComponent<LifeController>().TimeBonus();
//			}


            JailCamera.SetActive(true);
            Debug.Log("Victory");
            Invoke("GameOver", 1.5f);
            for (int i = 0; i <= 5; i++) {
                inGameUI[i].gameObject.SetActive(false);
            }
        }
    }

    public void FinishedGame() {
        Debug.Log("Restart");
        Application.LoadLevel("Menu Screen");
    }

    public void GameOver() {
        Time.timeScale = 0f;
        //Time.fixedDeltaTime = 0f;
    }
    public float ActualTime = 180f;
	public float levelTime = 360f;

    private void ClearAllGlows() {
        for (int i = 0; i < People.childCount; i++) {
            var child = People.GetChild(i);
            try {
                child.GetComponent<Shopper>().HightlightIcon.SetActive(false);
                child.GetComponent<Shopper>().SuspiciousIcon.SetActive(false);
                child.GetComponent<Shopper>().IsSuspicious = false;
                child.GetComponent<Shopper>().Highlighted = false;
                child.GetComponent<Shopper>().Darken(false);
            } catch (Exception e) {

            }
        }
    }
    
    private void GetCriminal() {
        //Find and pick a random criminal
        AnnouncementSound.Play(); //Audio - Name of Audio source.
        Time.timeScale = 1f;
        //Time.fixedDeltaTime = 1f;
        var people = GameObject.Find("BlockPeopleParent");
        var randomCriminal = people.transform.GetChild(UnityEngine.Random.Range(0, people.transform.childCount));
        randomCriminal.GetComponent<Shopper>().IsCriminal = true;
        CriminalDebug = randomCriminal.gameObject;
        var blockPerson = randomCriminal.GetComponent<BlockPersonGen>();

        InfoPanel.Find("SkinText").GetComponent<Text>().text = " •  " + blockPerson._skinList[blockPerson.theChosenSkin].name;

        if (blockPerson.hasHat) {
            InfoPanel.Find("HatText").GetComponent<Text>().text = " •  " + blockPerson._hatsList[blockPerson.theChosenHat].name;
        } else {
            InfoPanel.Find("HatText").GetComponent<Text>().text = " •  None";
        }

        if (blockPerson.hasHair) {
			InfoPanel.Find("HairText").GetComponent<Text>().text = " •  " + blockPerson._hairList[blockPerson.theChosenHair].name;
        } else {
			InfoPanel.Find("HairText").GetComponent<Text>().text = " •  None";
        }

        if (blockPerson.hasGlasses) {
			InfoPanel.Find("GlassesText").GetComponent<Text>().text = " •  " + blockPerson._glassesList[blockPerson.theChosenGlasses].name;
        } else {
			InfoPanel.Find("GlassesText").GetComponent<Text>().text = " •  None";
        }

        if (blockPerson.hasFacialHair) {
			InfoPanel.Find("FacialHairText").GetComponent<Text>().text = " •  " + blockPerson._facialHairList[blockPerson.theChosenFacialHair].name;
        } else {
            InfoPanel.Find("FacialHairText").GetComponent<Text>().text = " •  None";
        }

        if (blockPerson.hasAccessory) {
			InfoPanel.Find("AccessoryText").GetComponent<Text>().text = " •  " + blockPerson._accessoryList[blockPerson.theChosenAccessory].name;
        } else {
			InfoPanel.Find("AccessoryText").GetComponent<Text>().text = " •  None";
        }

        if (blockPerson.hasShirt) {
			InfoPanel.Find("ShirtText").GetComponent<Text>().text = " •  " + blockPerson._shirtList[blockPerson.theChosenShirt].name;
        } else {
			InfoPanel.Find("ShirtText").GetComponent<Text>().text = " •  None";
        }
    }

    private bool hintSoundPlayed;
    private float revealInteval = 10f;

    private void Update() {

        
        ActualTime -= Time.deltaTime;
		levelTime -= Time.deltaTime;
		if (RoughlyEqual(ActualTime, (180f - revealInteval))) {
            if (!HintSound.isPlaying) {
                HintSound.Play();
            }
            InfoPanel.Find("HatText").GetComponent<Text>().enabled = true;
        }
        
		if (RoughlyEqual(ActualTime, (180f - revealInteval * 2))) {
            if (!HintSound.isPlaying) {
                HintSound.Play();
            }
            InfoPanel.Find("HairText").GetComponent<Text>().enabled = true;
        }
		if (RoughlyEqual(ActualTime, (180f - revealInteval * 3))) {
            if (!HintSound.isPlaying) {
                HintSound.Play();
            }
            InfoPanel.Find("GlassesText").GetComponent<Text>().enabled = true;
        }
		if (RoughlyEqual(ActualTime, (180f - revealInteval * 4))) {
            if (!HintSound.isPlaying) {
                HintSound.Play();
            }
            InfoPanel.Find("FacialHairText").GetComponent<Text>().enabled = true;
        }
		if (RoughlyEqual(ActualTime, (180f - revealInteval * 5))) {
            if (!HintSound.isPlaying) {
                HintSound.Play();
            }
            InfoPanel.Find("AccessoryText").GetComponent<Text>().enabled = true;
        }
		if (RoughlyEqual(ActualTime, (180f - revealInteval * 6))) {
            if (!HintSound.isPlaying) {
                HintSound.Play();
            }
            InfoPanel.Find("ShirtText").GetComponent<Text>().enabled = true;
		}
        //HintSound.Play(); //Audio - Name of Audio source.
    }

    private static bool RoughlyEqual(float a, float b) {
        float treshold = 1f; //how much roughly
        return (Math.Abs(a - b) < treshold);
    }
}
