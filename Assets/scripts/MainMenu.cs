using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class MainMenu : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		// the size and location of the main menu
		GUI.BeginGroup(new Rect(Screen.width/2 - 50,Screen.height/2 - 50,100,150));
		GUI.Box(new Rect(0,0,100,200),"Main Menu");
		if (GUI.Button(new Rect(10,30,80,30),"Start Game"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
		}
		if (GUI.Button(new Rect(10,70,80,30),"Help"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Help");
		}
		if (GUI.Button(new Rect(10,110,80,30),"Exit"))
		{
			Application.Quit();
		}

		GUI.EndGroup();
	}
}
