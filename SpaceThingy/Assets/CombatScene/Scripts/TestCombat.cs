using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCombat : MonoBehaviour
{
	void Start()
	{
		CharacterCreator characterCreator = CharacterCreator.Instance;
		CombatManager manager = CombatManager.Instance;

	

		List<Character> characters = new List<Character>();
		characters.Add(characterCreator.createSniper(1, false));
		List<Vector2> chlocation = new List<Vector2>();
		chlocation.Add(new Vector2(0,0));

		List<Character> enemies = new List<Character>();
		enemies.Add(characterCreator.createSniper(0,false));
		List<Vector2> eLocation = new List<Vector2>();
		eLocation.Add(new Vector2(3,3));

		//CombatState cs = new CombatState(map, characters, enemies, chlocation, eLocation, 0);
		//manager.startCombat(cs);
	}
}
