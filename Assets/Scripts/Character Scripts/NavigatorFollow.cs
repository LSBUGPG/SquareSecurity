using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavigatorFollow : MonoBehaviour
{
    private NavMeshAgent NavAgent;
    private GameObject[] Destinations;

    // Use this for initialization
    void Awake()
    {
        Destinations = GameObject.FindGameObjectsWithTag("Destination");
        NavAgent = GetComponent<NavMeshAgent>();
		StartCoroutine (AI ());
    }

	IEnumerator AI()
	{
		while (true) {
			yield return StartCoroutine (WaitToEnterShop ());
			yield return StartCoroutine (WaitAroundAndNotDoMuch ());
		}
	}

    // Update is called once per frame
	IEnumerator WaitToEnterShop()
    {
		NavAgent.SetDestination(Destinations[Random.Range(0, Destinations.Length)].transform.position); //Selects a new location to walk to
		yield return new WaitUntil (() => Vector3.Distance (NavAgent.destination, transform.position) <= NavAgent.stoppingDistance);
		NavMeshHit navMeshHit;
		NavAgent.SamplePathPosition (NavMesh.AllAreas, 0.0f, out navMeshHit);
		NavAgent.areaMask = navMeshHit.mask;
    }

    IEnumerator WaitAroundAndNotDoMuch() {

		float time = Random.Range(15, 25);
		while (time > 0.0f) {
			Vector3 randomPosition = transform.position + Random.onUnitSphere * NavAgent.height * 2.0f;
			randomPosition.y = transform.position.y;
			NavMeshHit navMeshHit;
			NavMesh.SamplePosition (randomPosition, out navMeshHit, NavAgent.height * 2.0f, NavAgent.areaMask);
			NavAgent.SetDestination (navMeshHit.position);

			while (Vector3.Distance (NavAgent.destination, transform.position) > NavAgent.stoppingDistance) {
				time -= Time.deltaTime;
				yield return null;
			}

            time -= Time.deltaTime;
            yield return null;
		}

		NavAgent.areaMask = NavMesh.AllAreas; //Allows people to enter all rooms
    }

}
//Lewis, Paul, Alan & Kyle Code