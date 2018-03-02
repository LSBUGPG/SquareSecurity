using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour{

    public GameObject blockObj;
    public Transform blockPeopleParent;
    public CriminalManager CriminalManager;
    public Transform SpawnPointsParent;

    public List<string> arrestReasons = new List<string>() {
        "Stealing a birthday balloon",
        "Godawful dancing",
        "Breaking a pinkie promise",
        "Putting mayo on hotdogs",
        "Being so damn beatiful",
        "Calling a shopper mean names",
        "Places toilet paper under",
        "Tried to mess with Lewis Johnson"
    };

    public List<string> names = new List<string>() {
        "Lewis Johnson",
		"Jay Semplis",
        "Siobhan Thomas",
        "Carlos Evans-Goody",
        "Joshua Child",
        "Karl Alexander",
        "Alan Teacherman",
        "Kevin Sosa",
        "Charlie Adams",
        "Murray Illman",
        "John Thomas",
        "Thomas Johnson",
        "Jamie Hagen",
        "Jack Gileas",
        "Tobias Person",
        "Hayden Glasses",
        "Amy Johnson",
        "Jenny Katie",
        "Sarah Illman",
        "Ellie Child",
        "Polly Vonfredrick",
        "Lisa Sosa",
        "Lily Flowers",
        "Katie Jennifer",
        "Francine Potter",
        "Jane Potter"
    };

    // Use this for initialisation
    public void Start(){

        GameObject[] Destinations = GameObject.FindGameObjectsWithTag("Destination");

        var nameCounter = 0;
        for (int i = 0; i < SpawnPointsParent.childCount; i++) {
            for (int j = 0; j < SpawnPointsParent.GetChild(i).GetComponent<SpawnPoint>().amountToSpawnByNumber; j++, nameCounter++) {
                var blockInstance = Instantiate(blockObj, SpawnPointsParent.GetChild(i).transform.position, new Quaternion(), blockPeopleParent);

                try {
                    blockInstance.GetComponent<BlockPersonGen>().BlockPersonName = names[nameCounter];
                } catch(ArgumentOutOfRangeException e) {
                    Debug.LogError("We need more names in the SpawnManger.names collection.");
                }

                blockInstance.name = String.Format("Block Person ({0})", names[nameCounter]);
                blockInstance.GetComponent<BlockPersonGen>().Crime = arrestReasons[UnityEngine.Random.Range(0, arrestReasons.Count)];
                //Set follow target
                GameObject RandomDest = Destinations[UnityEngine.Random.Range(0, Destinations.Length)];
                blockInstance.GetComponent<NavMeshAgent>().destination = RandomDest.transform.position;
                blockInstance.GetComponent<NavMeshAgent>().avoidancePriority = nameCounter;
            }
        }

        // Removes duplicates for parent
        for (int i = 0; i < blockPeopleParent.childCount; i++){
            for (int j = 0; j < blockPeopleParent.childCount; j++){

                var child1 = blockPeopleParent.GetChild(i);
                var child2 = blockPeopleParent.GetChild(j);

                if (i != j && child1.GetComponent<BlockPersonGen>().Equals(child2.GetComponent<BlockPersonGen>()))
                {
                    //Batman
                    child2.parent = null;
                    //This kills any twins
                    Destroy(child2.gameObject);
                }
            }
        }

        Debug.Log("Character Spawn Complete. (" + blockPeopleParent.childCount + " children)");
        CriminalManager.CriminalsLeft();
    }
}