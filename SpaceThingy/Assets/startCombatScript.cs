using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class startCombatScript : MonoBehaviour
{
	public List<GameObject> team1, team2;
	public Dropdown dd1, dd2;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void click()
	{
		List<Character> chars1 = new List<Character>();
		int num = dd1.value;
		for (int i = 0; i < num; i++)
		{
			bool ai = team1[i].transform.GetChild(2).GetComponent<Toggle>().isOn;
			int index = team1[i].transform.GetChild(0).GetComponent<Dropdown>().value;
			string jobString = team1[i].transform.GetChild(0).GetComponent<Dropdown>().options[index].text;
			Character cha = stringToCharacter(jobString, ai, 0);
			chars1.Add(cha);
		}

		List<Character> chars2 = new List<Character>();
		num = dd2.value;
		for (int i = 0; i < num; i++)
		{
			bool ai = team2[i].transform.GetChild(2).GetComponent<Toggle>().isOn;
			int index = team2[i].transform.GetChild(0).GetComponent<Dropdown>().value;
			string jobString = team2[i].transform.GetChild(0).GetComponent<Dropdown>().options[index].text;
			Character cha = stringToCharacter(jobString, ai, 1);
			chars2.Add(cha);
		}

		startCombat(chars1, chars2);
		transform.parent.gameObject.SetActive(false);
	}

	private Character stringToCharacter(string jobString, bool ai, int team)
	{
		switch (jobString)
		{
			case "Sniper":
				return CharacterCreator.Instance.createSniper(team, ai);
			case "Medic":
				return CharacterCreator.Instance.createMedic(team, ai);
			case "Bazerker":
				return CharacterCreator.Instance.createBazerker(team, ai);
		}
		return null;
	}

	public void startCombat(List<Character> team1, List<Character> team2)
	{
		//generate map
		//GameMap map = MapGeneratorScript.Instance.generateMap(MapGeneratorScript.Instance.types[0], CombatManager.Instance.sizeX, CombatManager.Instance.sizeY);

		//place caracters on the map
		/*List<Vector2> st = map.team1StartingLocation;// maybe deep copy instand
		for (int i = 0; i < team1.Count; i++)
		{
			int index = Random.Range(0, st.Count);
		//	team1[i].loc = st[index];
			map.addCharacter(team1[i], st[index]);
			st.RemoveAt(index);
		}
		st = map.team2StartingLocation;
		for (int i = 0; i < team2.Count; i++)
		{
			int index = Random.Range(0, st.Count);
		//	team2[i].loc = st[index];
			map.addCharacter(team2[i], st[index]);
			st.RemoveAt(index);
		}*/
		//return state
		CombatManager.Instance.startCombat(new CombatState(team1, team2, 0));
	}
}
