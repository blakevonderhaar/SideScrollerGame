using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScript : MonoBehaviour {


    private GameObject[] characterList;
	public int index;

	void Start () {

        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        //Fill the array with our models
        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // Toggle off their renderer
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }

		print (index);

        //Toggle on the first index
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }

	}

    public void ToggleLeft()
    {
        //Toggle off the current model

        characterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = characterList.Length - 1;

        //Toggle on the new model

        characterList[index].SetActive(true);
    }
    public void ToggleRight()
    {
        //Toggle off the current model

        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
            index = 0;

        //Toggle on the new model

        characterList[index].SetActive(true);
    }

    public void continueButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Scene");
    }
    
}
