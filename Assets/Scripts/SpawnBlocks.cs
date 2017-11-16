using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject blockObj;
    public Transform people;
    public CriminalManager CriminalManager;
    // Use this for initialisation
    void Start()
    {
        for (int i = 0; i < 10; i++) //The 2nd number indicates how many people spawn. This is added by the 2nd number below.
        {
            for (int j = 0; j < 10; j++) //The 2nd number indicates how many people spawn. This is added by the 2nd number above.
            {
                var blockInstance = Instantiate(blockObj, new Vector3(0, 0, 0), new Quaternion());
                var r = (GameObject)blockInstance;
                r.transform.SetParent(people);
                r.transform.position = new Vector3((i * 20) + 20, 20, (j * 20) + 20);

                //Set follow target
                GameObject[] Destinations = GameObject.FindGameObjectsWithTag("Destination");
                GameObject RandomDest = Destinations[Random.Range(0, Destinations.Length)];
                r.GetComponent<NavigatorFollow>().Destination = RandomDest.transform;
            }

        }

        for (int i = 0; i < people.childCount; i++)
        {
            for (int j = 0; j < people.childCount; j++)
            {

                var child1 = people.GetChild(i);
                var child2 = people.GetChild(j);

                if (i != j && child1.GetComponent<BlockPersonGen>().Equals(child2.GetComponent<BlockPersonGen>()))
                {
                    //Batman
                    child2.parent = null;
                    //This kills any twins
                    Destroy(child2.gameObject);
                }
            }
        }

        Debug.Log("Character Spawn Complete. (" + people.childCount + " children)");
        CriminalManager.CriminalsLeft();
    }
}