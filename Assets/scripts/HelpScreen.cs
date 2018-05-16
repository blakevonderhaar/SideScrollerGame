using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		GUI.color = Color.white;
		GUI.backgroundColor = Color.green;
		if (GUI.Button (new Rect (0, 0, 100, 100), "Go Back")) 
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}
		GUI.Box(new Rect(0,0,Screen.width,Screen.height),"How to play");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6,500,20),"Use A to walk left, D to walk right");
		GUI.Label(new Rect(Screen.width/3,Screen.height/5,500,20),"Hold shift to run");
		GUI.Label(new Rect(Screen.width/3,Screen.height/4.5f,500,20),"Spacebar to jump");
		GUI.Label(new Rect(Screen.width/3,Screen.height/4,500,20),"Left mouse click to attack");
	}
}
