using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PupolateAbilitiesScript : MonoBehaviour
{
	public GameObject buttonPrefab;
	public GameObject useItemButtonPrefab;
	public GameObject cancelButtonPrefab;

	private List<GameObject> buttons;


	// Use this for initialization
	void Start()
	{
		buttons = new List<GameObject>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void populate(List<Ability> abilities, Vector2 target, Character character)
	{
		clearList();
		GameObject button;
		if (abilities != null)
		{
			if (character.useItem)
			{
				if (character.toUse.canUse(character, target, character.inventory))
				{
					button = Instantiate(useItemButtonPrefab,transform);
					button.GetComponentInChildren<Text>().text = "use " + character.toUse.name;
					button.GetComponent<useItemScript>().init(target);
					buttons.Add(button);
				}
			}
			else
			{
				for (int i = 0; i < abilities.Count; i++)
				{
					button = Instantiate(buttonPrefab,transform);
					button.GetComponent<ChooseActionButtonScript>().init(abilities[i], target);
					buttons.Add(button);
				}
			}
		}
		button = Instantiate(cancelButtonPrefab,transform);
		buttons.Add(button);
	}

	private void clearList()
	{
		for (int i = buttons.Count - 1; i >= 0; i--)
		{
			Destroy(buttons[i]);
		}
	}
}
