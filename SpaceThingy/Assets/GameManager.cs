using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public List<Character> playerCharacters { get; set; }
	public Inventory inventory { get; private set; }
	private CharacterCreator characterCreator;

	void Start()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		Instance = this;
		DontDestroyOnLoad(this);
		playerCharacters = new List<Character>();
		inventory = new Inventory();
		characterCreator = GetComponent<CharacterCreator>();
	}

	public void startGame()
	{
		generateCharacters();

		SceneManager.LoadScene("CharacterCreation");
	}

	public void continueGame()
	{

	}

	private void generateCharacters()
	{
		//Inventory inventory = new Inventory();
		//playerCharacters.Add(characterCreator.createCharacter(characterCreator.sniperAsset, 0, inventory));
		//playerCharacters.Add(characterCreator.createCharacter(characterCreator.medicAsset, 0, inventory));
		//playerCharacters.Add(characterCreator.createCharacter(characterCreator.bazerkerAsset, 0, inventory));
	}


	//apperently happaned when the game close... will be use to save the game.
	void OnApplicationQuit()
	{

	}
}
