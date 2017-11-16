using UnityEngine;
using System.Collections;


public class NavigatorFollow : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent ThisAgent = null;
    public Transform Destination = null;
	// Use this for initialization
	void Awake () {
        ThisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (Destination != null)
        {
            float DistanceToDest = Vector3.Distance(Destination.position, transform.position);

            //Debug.Log(DistanceToDest);

            if (DistanceToDest <= ThisAgent.stoppingDistance)
            {
				Debug.Log ("new target");
                //We have arrived. Now pick new destination
                GameObject[] Destinations = GameObject.FindGameObjectsWithTag("Destination");
                Destination = Destinations[Random.Range(0, Destinations.Length)].transform;
            }
            ThisAgent.SetDestination(Destination.position);

        }
 
    }
}
