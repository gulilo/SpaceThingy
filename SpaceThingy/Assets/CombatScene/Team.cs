using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
	public List<Character> characters;
	public int deads { get; private set; }
	public int alives { get; private set; }
	public List<Character> aliveCharacters;

	public Team()
	{
		characters = new List<Character>();
		aliveCharacters = new List<Character>();
		alives = 0;
		deads = 0;
	}

	public void addCharacter(Character c)
	{
		characters.Add(c);
		aliveCharacters.Add(c);
		alives++;
	}

	public void kill(Character c)
	{
		aliveCharacters.Remove(c);
		deads++;
		alives--;
		Debug.Log("blbal");
	}

	public bool contain(Character c)
	{
		return characters.Contains(c);
	}

	public Character this[int index]
	{
		get { return aliveCharacters[index]; }
	}
}
