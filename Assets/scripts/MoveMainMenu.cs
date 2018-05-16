using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-.035f,0,0);
		if (transform.position.x <= -36f) {
			transform.position = new Vector3 (36f, 0, 0);
		}
	}
}
