using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BlockPersonGen : MonoBehaviour {

    public Transform SpawnPosition;
    public string BlockPersonName;
    public string Crime;

    [SerializeField]
    public List<GameObject> _bigHairList;

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

    public Material theChosenSkin;
    public GameObject theChosenHat;
    public GameObject theChosenHair;
    public GameObject theChosenGlasses;
    public GameObject theChosenFacialHair;
    public GameObject theChosenAccessory;
    public GameObject theChosenShirt;
    public Material theChosenHatColour;
    public Material theChosenHairColour;
    public Material theChosenGlassesColour;
    public Material theChosenShirtColour;
    public Material theChosenBodyColour;

    public bool
        hasHat = false,
        hasHair = false,
        hasGlasses = false,
        hasFacialHair = false,
        hasAccessory = false,
        hasShirt = false,
        bigHair = false,
        randomGeneration = true;

    void GetRandomMaterial(ref Material material, List<Material> list)
    {
        material = list[Random.Range(0, list.Count)];
    }

    void GetRandomObject(ref GameObject theObject, List<GameObject> list)
    {
        theObject = list[Random.Range(0, list.Count)];
    }


    // Use this for initialization
    void Awake() {
        Transform hatPos = transform.Find("HatPos").transform;
        Transform hairPos = transform.Find("HairPos").transform;
        Transform glassesPos = transform.Find("GlassesPos").transform;
        Transform facialHairPos = transform.Find("FacialHairPos").transform;
        Transform accessoryPos = transform.Find("AccessoryPos").transform;
        Transform shirtPos = transform.Find("ShirtPos").transform;
        Transform meshPos = transform.Find("MeshPos").transform;

        if (randomGeneration)
        {
            GetRandomMaterial(ref theChosenSkin, _skinList);
            if (Random.Range(1, 100) > 10)
            {
                GetRandomObject(ref theChosenHair, _hairList);
                bigHair = _bigHairList.Contains(theChosenHair);
            }
            if (!bigHair && Random.Range(1, 100) > 10)
            {
                GetRandomObject(ref theChosenHat, _hatsList);
            }
            if (Random.Range(1, 100) > 10)
            {
                GetRandomObject(ref theChosenGlasses, _glassesList);
            }
            if (Random.Range(1, 100) > 75)
            {
                GetRandomObject(ref theChosenFacialHair, _facialHairList);
            }
            if (Random.Range(0, 5) == 0)
            {
                GetRandomObject(ref theChosenAccessory, _accessoryList);
            }
            if (Random.Range(1, 100) > 10)
            {
                GetRandomObject(ref theChosenShirt, _shirtList);
            }

            GetRandomMaterial(ref theChosenHatColour, _hatColourList); //Hat Colour Random
            GetRandomMaterial(ref theChosenHairColour, _hairColourList); //Hair Colour Random
            GetRandomMaterial(ref theChosenGlassesColour, _glassesColourList); //Glasses Colour Random
            GetRandomMaterial(ref theChosenShirtColour, _shirtColourList); //Shirt Colour Random
            GetRandomMaterial(ref theChosenBodyColour, _bodyColourList); //Shirt Colour Random
        }
        randomGeneration = false;

        // Spawn body
        var body = Instantiate(_blockPersonGameObject, meshPos.localPosition, Quaternion.identity, meshPos);
        //body.transform.GetChild(1).GetComponent<Renderer>().material = _skinList[theChosenSkin];
        // Spawn Accessory pieces

        if (theChosenAccessory != null) {
            Instantiate(theChosenAccessory, accessoryPos.localPosition, Quaternion.identity, accessoryPos);
            hasAccessory = true;
        }

        //Hair pieces
        if (theChosenHair != null) {
            Instantiate(theChosenHair, hairPos.localPosition, Quaternion.identity, hairPos);
            hasHair = true;
        }

        //Hat pieces
        if (theChosenHat != null) {
            var hat = Instantiate(theChosenHat, hatPos.localPosition, Quaternion.identity, hatPos);
            hasHat = true;
        }

        //Glass pieces
        if (theChosenGlasses != null) {
            Instantiate(theChosenGlasses, glassesPos.localPosition, Quaternion.identity, glassesPos);
            hasGlasses = true;
        }

        //Facial Hair pieces
        if (theChosenFacialHair != null) {
            Instantiate(theChosenFacialHair, facialHairPos.localPosition, Quaternion.identity, facialHairPos);
            hasFacialHair = true;
        }

        //Shirt pieces
        if (theChosenShirt != null) {
            Instantiate(theChosenShirt, shirtPos.localPosition, Quaternion.identity, shirtPos);
            hasShirt = true;
        }

        foreach (var colourScript in GetComponentsInChildren<SetColour>()) {
            colourScript.ChangeColour("skin", theChosenSkin);
            colourScript.ChangeColour("hat", theChosenHatColour);
            colourScript.ChangeColour("hair", theChosenHairColour);
            colourScript.ChangeColour("glasses", theChosenGlassesColour);
            colourScript.ChangeColour("shirt", theChosenShirtColour);
            colourScript.ChangeColour("body", theChosenBodyColour);
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


