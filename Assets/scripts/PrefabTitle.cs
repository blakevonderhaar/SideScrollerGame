using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTitle : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(tag == "AI")
			anim.SetInteger ("whichAnim", 4);
		if(tag == "Player")
			anim.SetInteger ("WhichAnim", 4);
	}
}
