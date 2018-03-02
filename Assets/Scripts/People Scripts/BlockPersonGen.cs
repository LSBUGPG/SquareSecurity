using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BlockPersonGen : MonoBehaviour {

    public Transform SpawnPosition;
    public string BlockPersonName;
    public string Crime;

    [SerializeField]
    public List<bool> _bigHairList;

    [SerializeField]
    public List<GameObject> _hatsList;
    [SerializeField]
    public List<GameObject> _hairList;
    [SerializeField]
    public List<GameObject> _glassesList;
    [SerializeField]
    public List<GameObject> _facialHairList;
    [SerializeField]
    public List<GameObject> _shirtList;
    [SerializeField]
    public List<GameObject> _accessoryList;

    [SerializeField]
    public List<Material> _skinList;
    [SerializeField]
    public List<Material> _hatColourList;
    [SerializeField]
    public List<Material> _hairColourList;
    [SerializeField]
    public List<Material> _glassesColourList;
    [SerializeField]
    public List<Material> _shirtColourList;
    [SerializeField]
    public List<Material> _bodyColourList;

    //[SerializeField]
    //public List<GameObject> _accessoryColourList;
    //[SerializeField]
    //public List<GameObject> _shirtColourList;
    //[SerializeField]

    public GameObject _blockPersonGameObject;

    public int theChosenSkin,
        theChosenHat,
        theChosenHair,
        theChosenGlasses,
        theChosenFacialHair,
        theChosenAccessory,
        theChosenShirt,
        theChosenHatColour,
        theChosenHairColour,
        theChosenGlassesColour,
        theChosenShirtColour,
        theChosenBodyColour;

    public bool
        hasHat = false,
        hasHair = false,
        hasGlasses = false,
        hasFacialHair = false,
        hasAccessory = false,
        hasShirt = false,
        bigHair = false;

    // Use this for initialization
    void Awake() {
        Transform hatPos = transform.Find("HatPos").transform;
        Transform hairPos = transform.Find("HairPos").transform;
        Transform glassesPos = transform.Find("GlassesPos").transform;
        Transform facialHairPos = transform.Find("FacialHairPos").transform;
        Transform accessoryPos = transform.Find("AccessoryPos").transform;
        Transform shirtPos = transform.Find("ShirtPos").transform;
        Transform meshPos = transform.Find("MeshPos").transform;

        theChosenSkin = Random.Range(0, _skinList.Count);
        theChosenHat = Random.Range(0, _hatsList.Count);
        theChosenHair = Random.Range(0, _hairList.Count);
        theChosenGlasses = Random.Range(0, _glassesList.Count);
        theChosenFacialHair = Random.Range(0, _facialHairList.Count);
        theChosenAccessory = Random.Range(0, _accessoryList.Count);
        theChosenShirt = Random.Range(0, _shirtList.Count);

        theChosenHatColour = Random.Range(0, _hatColourList.Count); //Hat Colour Random
        theChosenHairColour = Random.Range(0, _hairColourList.Count); //Hair Colour Random
        theChosenGlassesColour = Random.Range(0, _glassesColourList.Count); //Glasses Colour Random
        theChosenShirtColour = Random.Range(0, _shirtColourList.Count); //Shirt Colour Random
        theChosenBodyColour = Random.Range(0, _bodyColourList.Count); //Shirt Colour Random

        // Spawn body
        var body = Instantiate(_blockPersonGameObject, meshPos.localPosition, new Quaternion(0, 0, 0, 0), meshPos);
        //body.transform.GetChild(1).GetComponent<Renderer>().material = _skinList[theChosenSkin];
        // Spawn Accessory pieces

        if (Random.Range(0, 5) == 0) {
            Instantiate(_accessoryList[theChosenAccessory], accessoryPos.localPosition, new Quaternion(0, 0, 0, 0), accessoryPos);
            hasAccessory = true;
        }

        //Hair pieces
        if (Random.Range(1, 100) > 10) {
            Instantiate(_hairList[theChosenHair], hairPos.localPosition, new Quaternion(0, 0, 0, 0), hairPos);
            hasHair = true;
            bigHair = _bigHairList[theChosenHair];
        }

        //Hat pieces
        if (!bigHair && Random.Range(1, 100) > 10) {
            var hat = Instantiate(_hatsList[theChosenHat], hatPos.localPosition, new Quaternion(0, 0, 0, 0), hatPos);
            //hat.transform.GetChild (0).GetComponent<Renderer> ().material = _skinList [theChosenSkin];
            hasHat = true;
        }

        //Glass pieces
        if (Random.Range(1, 100) > 10) {
            Instantiate(_glassesList[theChosenGlasses], glassesPos.localPosition, new Quaternion(0, 0, 0, 0), glassesPos);
            hasGlasses = true;
        }

        //Facial Hair pieces
        if (Random.Range(1, 100) > 75) {
            Instantiate(_facialHairList[theChosenFacialHair], facialHairPos.localPosition, new Quaternion(0, 0, 0, 0), facialHairPos);
            hasFacialHair = true;
        }

        //Shirt pieces
        if (Random.Range(1, 100) > 10) {
            Instantiate(_shirtList[theChosenShirt], shirtPos.localPosition, new Quaternion(0, 0, 0, 0), shirtPos);
            hasShirt = true;
        }

        foreach (var colourScript in GetComponentsInChildren<SetColour>()) {
            colourScript.ChangeColour("skin", _skinList[theChosenSkin]);
            colourScript.ChangeColour("hat", _hatColourList[theChosenHatColour]);
            colourScript.ChangeColour("hair", _hairColourList[theChosenHairColour]);
            colourScript.ChangeColour("glasses", _glassesColourList[theChosenGlassesColour]);
            colourScript.ChangeColour("shirt", _shirtColourList[theChosenShirtColour]);
            colourScript.ChangeColour("body", _bodyColourList[theChosenBodyColour]);
        }
        transform.position = new Vector3(0, 0, 0);
    }

    public bool Equals(BlockPersonGen y) {
        return
            this.hasHat == y.hasHat &&
            this.hasHair == y.hasHair &&
            this.hasGlasses == y.hasGlasses &&
            this.hasFacialHair == y.hasFacialHair &&
            this.hasShirt == y.hasShirt &&
            this.hasAccessory == y.hasAccessory &&
            this.theChosenHat == y.theChosenHat &&
            this.theChosenHair == y.theChosenHair &&
            this.theChosenGlasses == y.theChosenGlasses &&
            this.theChosenFacialHair == y.theChosenFacialHair &&
            this.theChosenShirt == y.theChosenShirt &&
            this.theChosenAccessory == y.theChosenAccessory;
    }
}


