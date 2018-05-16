using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIHitbox : MonoBehaviour {

	public bool attack;
	public bool right;
	bool doThis;
	public Collider player;
	void Start () {
		attack = false;
		right = false;
		doThis = true;
		transform.position = transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
        
    }
	void OnTriggerEnter(Collider obj)
	{
		if (doThis && obj.tag == "Player") 
		{
			player = obj;
			doThis = false;
		}
		if (obj == player) 
		{
			if (player != null && transform.GetComponent<BoxCollider> ().bounds.center.x < obj.transform.position.x
			   && transform.GetComponent<BoxCollider> ().bounds.max.x > obj.transform.position.x) 
			{
				attack = true;
				right = true;
			}
			else if (player != null && transform.GetComponent<BoxCollider> ().bounds.center.x > obj.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.min.x < obj.transform.position.x) 
			{
				attack = true;
				right = false;
			}
		}
	}
	void OnTriggerStay(Collider obj)
	{
		if (obj == player) 
		{
			if (obj.GetComponent<Player> ().Health <= 0) 
			{
				player = null;
				attack = false;
			}
			if (player != null && transform.GetComponent<BoxCollider> ().bounds.center.x < obj.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.max.x > obj.transform.position.x) 
			{
				attack = true;
				right = true;
			}
			else if (player != null && transform.GetComponent<BoxCollider> ().bounds.center.x > obj.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.min.x < obj.transform.position.x) 
			{
				attack = true;
				right = false;
			}
		}
	}
	void OnTriggerExit(Collider obj)
	{
		player = null;
		attack = false;
		doThis = true;
	}
}
