using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MageFireball : NetworkBehaviour {
	float StartXPos;
	float AddXPos;
	bool MoveRight;
	// Use this for initialization
	void Start () {
		StartXPos = transform.position.x;
		AddXPos = transform.position.x;
		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		MoveRight = Player.GetComponent<Player> ().MoveRight;
	}
	
	// Update is called once per frame
	void Update () {
		if (MoveRight) {
			if (StartXPos + 3.0f > AddXPos) {
				AddXPos += 0.1f;
				transform.Translate (0.1f, 0.0f, 0.0f);
			} else {
				NetworkServer.Destroy (gameObject);
			}
		} else if (!MoveRight) {
			if (StartXPos - 3.0f < AddXPos) {
				AddXPos -= 0.1f;
				transform.Translate (-0.1f, 0.0f, 0.0f);
			} else {
				NetworkServer.Destroy (gameObject);
			}
		} 
	}

	void OnTriggerEnter(Collider Other){
		if (Other.tag == "AI") {
			NetworkServer.Destroy (gameObject);
		}
	}
}
