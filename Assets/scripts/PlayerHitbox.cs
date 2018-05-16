using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHitbox : MonoBehaviour
{

	public GameObject AI;

	void Start () {
		transform.position = transform.parent.position;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider Obj)
	{
		if (Obj.tag == "AI") 
		{
			AI = Obj.gameObject;
		}
	}
	public void AILocation(bool Direction){
		if(AI != null)
		if (transform.GetComponent<BoxCollider> ().bounds.center.x < AI.transform.position.x && transform.GetComponent<BoxCollider> ().bounds.max.x > AI.transform.position.x && Direction) {
			AI.GetComponent<AI> ().Damage (20);
		} else if (transform.GetComponent<BoxCollider> ().bounds.center.x > AI.transform.position.x && transform.GetComponent<BoxCollider> ().bounds.min.x < AI.transform.position.x && !Direction) {
			AI.GetComponent<AI> ().Damage (20);
		}
	}
		
}

