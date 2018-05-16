using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour {
	public int CharacterSelection;
	// Use this for initialization
	void Start () {
		
		CharacterSelection = 0;
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCharacter(int Index){
		CharacterSelection = Index;
	}

	public int GetCharacter(){
		return(CharacterSelection);
	}
}
