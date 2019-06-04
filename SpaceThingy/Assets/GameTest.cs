using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;

public class GameTest
{
	[Test]
	public void CharacterShotAfterSomeTime()
	{
		Character c1 = new PlayerCharacter(new Stat(50), null, null, null, null, 100, null, null, null, 1, null, new TestShot(1));
		Character c2 = new PlayerCharacter(null, null, null, null, null, 100, null, null, null, 1, null,null);

		List<Character> team1 = new List<Character> {c1};
		List<Character> team2 = new List<Character> {c2};

		c1.target = c2;

		CombatState state = new CombatState(team1, team2);

		state.timePassed(1.1f);

		Assert.AreEqual(90, c2.currentHp);
	}

	[Test]
	public void CharacterShotFewTimes()
	{
		Character c1 = new PlayerCharacter(new Stat(50), null, null, null, null, 100, null, null, null, 1, null, new TestShot(1));
		Character c2 = new PlayerCharacter(null, null, null, null, null, 100, null, null, null, 1, null, null);

		List<Character> team1 = new List<Character> { c1 };
		List<Character> team2 = new List<Character> { c2 };

		c1.target = c2;

		CombatState state = new CombatState(team1, team2);

		state.timePassed(2.5f);

		Assert.AreEqual(80, c2.currentHp);
	}

}
