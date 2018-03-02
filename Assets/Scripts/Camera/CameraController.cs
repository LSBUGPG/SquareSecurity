using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public GameObject[] cameras;
    public int roomNum = 1;
    public GameObject[] roomIndi;
    public AudioSource CameraSwapSound; //Audio - public AudioSource (What you want to name it)
    public Color theNewColour = new Color(0.1f, 0.3f, 0.4f);
    public Color[] roomColour;

    // Use this for initialization
    void Start()
    {

    }

    private void OnDisable() {
        for (int i = 0; i <= 11; i++) {
            cameras[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Q)) {
            CameraSwapSound.Play(); //Audio - Name of Audio source.
        }

        if (Input.GetKeyDown(KeyCode.Q) && roomNum == 1)
        {

            cameras[0].SetActive(!cameras[0].activeSelf);
            cameras[1].SetActive(!cameras[1].activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Q) && roomNum == 2)
        {
            cameras[2].SetActive(!cameras[2].activeSelf);
            cameras[3].SetActive(!cameras[3].activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Q) && roomNum == 3)
        {
            cameras[4].SetActive(!cameras[4].activeSelf);
            cameras[5].SetActive(!cameras[5].activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Q) && roomNum == 4)
        {
            cameras[6].SetActive(!cameras[6].activeSelf);
            cameras[7].SetActive(!cameras[7].activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Q) && roomNum == 5)
        {
            cameras[8].SetActive(!cameras[8].activeSelf);
            cameras[9].SetActive(!cameras[9].activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Q) && roomNum == 6) {
            cameras[10].SetActive(!cameras[10].activeSelf);
            cameras[11].SetActive(!cameras[11].activeSelf);
        }

        // Below is all the code which is used to swap rooms

        if (Input.GetKeyDown(KeyCode.Alpha1) && roomNum != 1)
        {
            roomNum = 1;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 11; i++)
            {
                cameras[i].SetActive(i == 0);
            }
            for (int i = 0; i <= 5; i++) {
                if (i != 0) {
                    roomIndi[i].GetComponent<Image>().color = Color.white;
                } else {
                    roomIndi[i].GetComponent<Image>().color = roomColour[0];
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && roomNum != 2)
        {
            roomNum = 2;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 11; i++)
            {
                cameras[i].SetActive(i == 2);
            }
            for (int i = 0; i <= 5; i++) {
                if (i != 1) {
                    roomIndi[i].GetComponent<Image>().color = Color.white;
                } else {
                    roomIndi[i].GetComponent<Image>().color = roomColour[1];
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && roomNum != 3)
        {
            roomNum = 3;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 11; i++)
            {
                cameras[i].SetActive(i == 4);
            }
            for (int i = 0; i <= 5; i++) {
                if (i != 2) {
                    roomIndi[i].GetComponent<Image>().color = Color.white;
                } else {
                    roomIndi[i].GetComponent<Image>().color = roomColour[2];
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && roomNum != 4)
        {
            roomNum = 4;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 11; i++)
            {
                cameras[i].SetActive(i == 6);
            }
            for (int i = 0; i <= 5; i++) {
                if (i != 3) {
                    roomIndi[i].GetComponent<Image>().color = Color.white;
                } else {
                    roomIndi[i].GetComponent<Image>().color = roomColour[3];
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && roomNum != 5)
        {
            roomNum = 5;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 11; i++)
            {
                cameras[i].SetActive(i == 8);
            }
            for (int i = 0; i <= 5; i++) {
                if (i != 4) {
                    roomIndi[i].GetComponent<Image>().color = Color.white;
                } else {
                    roomIndi[i].GetComponent<Image>().color = roomColour[4];
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && roomNum != 6) {
            roomNum = 6;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 11; i++) 
            {
                cameras[i].SetActive(i == 10);
            }
            for (int i = 0; i <= 5; i++) {
                if (i != 5) {
                    roomIndi[i].GetComponent<Image>().color = Color.white;
                } else {
                    roomIndi[i].GetComponent<Image>().color = roomColour[5];
                }
            }
        }
    }
}