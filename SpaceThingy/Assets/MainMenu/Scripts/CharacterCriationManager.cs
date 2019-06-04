using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCriationManager : MonoBehaviour
{
	public static CharacterCriationManager Instance;

	public GameObject[] characterPanel;
	public GameObject currentCharacterPanel;
	
	void Start ()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		currentCharacterPanel = characterPanel[0];

		List<Character> characters = GameManager.Instance.playerCharacters;

		for (int i = 0; i < characterPanel.Length;i++)
		{
			Text[] text = characterPanel[i].GetComponentsInChildren<Text>();
			text[1].text = characters[i].firstName;
			text[3].text = characters[i].lastName;
			text[5].text = characters[i].attack+"";
		}
	}

	public void changeTab(int index)
	{
		currentCharacterPanel.SetActive(false);
		currentCharacterPanel = characterPanel[index];
		currentCharacterPanel.SetActive(true);
	}
	
}
