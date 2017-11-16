using UnityEngine;
using System.Collections;

public class EnemyAttract : MonoBehaviour {

	public Transform Target;
	public Transform MyTransform;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		

	}
	void OnTriggerStay (Collider theCollision) {
		if (theCollision.gameObject.tag == "Player") {
			transform.LookAt (Target);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}	

}
}
