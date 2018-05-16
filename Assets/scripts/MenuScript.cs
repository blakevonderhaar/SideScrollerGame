using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

	private GameObject[] characterList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonClicked(int Chosen){
		GameObject Holder = GameObject.FindGameObjectWithTag ("Holder");
		if (Chosen == 0) {
			Holder.GetComponent<CharacterHolder> ().SetCharacter (Chosen);
			SceneManager.LoadScene ("Scene");
		} else if (Chosen == 1) {
			Holder.GetComponent<CharacterHolder> ().SetCharacter (Chosen);
			SceneManager.LoadScene ("Scene");
		} else if (Chosen == 2) {
			Holder.GetComponent<CharacterHolder> ().SetCharacter (Chosen);
			SceneManager.LoadScene ("Scene");
		} else if (Chosen == 3) {
			Holder.GetComponent<CharacterHolder> ().SetCharacter (Chosen);
			SceneManager.LoadScene ("Scene");
		}
	}
}
