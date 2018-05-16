using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChasePlayer : MonoBehaviour
{

	public bool right;
	bool doThis;
	public Collider player;
	// Use this for initialization
	void Start () {
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
		if (player != null && player.GetComponent<Player>().Health > 0) 
		{
			
			if (transform.GetComponent<BoxCollider> ().bounds.center.x < player.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.max.x > player.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.max.y > player.transform.position.y
				&& transform.GetComponent<BoxCollider> ().bounds.min.y < player.transform.position.y) 
			{
				
				right = true;
			}
			else if (transform.GetComponent<BoxCollider> ().bounds.center.x > player.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.min.x < player.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.max.y > player.transform.position.y
				&& transform.GetComponent<BoxCollider> ().bounds.min.y < player.transform.position.y) 
			{
				right = false;
			}
		}
	}
	void OnTriggerStay(Collider obj)
	{
		if (doThis && obj.tag == "Player") 
		{
			player = obj;
			doThis = false;
		}
		if (!doThis && obj.tag == "Player") 
		{
			if (transform.GetComponent<BoxCollider> ().bounds.center.x < obj.transform.position.x
			    && transform.GetComponent<BoxCollider> ().bounds.max.x > obj.transform.position.x
			    && obj.transform.position.x < player.transform.position.x) 
			{
				player = obj;
			} 
			else if (transform.GetComponent<BoxCollider> ().bounds.center.x > obj.transform.position.x
			    && transform.GetComponent<BoxCollider> ().bounds.min.x < obj.transform.position.x
			    && obj.transform.position.x > player.transform.position.x) 
			{
				player = obj;
			}

			doThis = false;
		}
		if (player != null && player.GetComponent<Player>().Health > 0) 
		{
			if (transform.GetComponent<BoxCollider> ().bounds.center.x < player.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.max.x > player.transform.position.x) 
			{
				right = true;
			}
			else if (transform.GetComponent<BoxCollider> ().bounds.center.x > player.transform.position.x
				&& transform.GetComponent<BoxCollider> ().bounds.min.x < player.transform.position.x) 
			{
				right = false;
			}
		}
	}
	void OnTriggerExit(Collider obj)
	{
		player = null;
		doThis = true;
	}
}
