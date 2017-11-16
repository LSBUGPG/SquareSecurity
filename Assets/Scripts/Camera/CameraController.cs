using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject[] cameras;
    public int roomNum = 1;
    public AudioSource CameraSwapSound; //Audio - public AudioSource (What you want to name it)

    // Use this for initialization
    void Start()
    {

    }

    private void OnDisable() {
        for (int i = 0; i <= 9; i++) {
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

        // Below is all the code which is used to swap rooms

        if (Input.GetKeyDown(KeyCode.Alpha1) && roomNum != 1)
        {
            roomNum = 1;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 9; i++)
            {
                cameras[i].SetActive(i == 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && roomNum != 2)
        {
            roomNum = 2;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 9; i++)
            {
                cameras[i].SetActive(i == 2);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && roomNum != 3)
        {
            roomNum = 3;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 9; i++)
            {
                cameras[i].SetActive(i == 4);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && roomNum != 4)
        {
            roomNum = 4;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 9; i++)
            {
                cameras[i].SetActive(i == 6);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && roomNum != 5)
        {
            roomNum = 5;
            CameraSwapSound.Play(); //Audio - Name of Audio source.
            for (int i = 0; i <= 9; i++)
            {
                cameras[i].SetActive(i == 8);
            }
        }
    }
}