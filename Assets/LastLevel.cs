using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevel : MonoBehaviour {

	public GameObject Character;
	public GameObject boss;

	// Use this for initialization
	public void  Start () {
		
		Instantiate(Character, new Vector3(0, 0, 0), transform.rotation);
		Instantiate (boss, new Vector3(5,0,0), transform.rotation);
	}

}
