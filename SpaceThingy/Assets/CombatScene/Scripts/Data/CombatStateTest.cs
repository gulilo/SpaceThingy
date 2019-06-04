using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class CombatStateTest
{
	[Test]
	public void timePassed()
	{
		List<Character> team1 = new List<Character>();
		Character player1 = new PlayerCharacter(null, null, null, null, null, 1, null, null, null, 1, null,null);
		player1.cooldown = 5;
		team1.Add(player1);
		List<Character> team2 = new List<Character>();
		Character player2 = new PlayerCharacter(null, null, null, null, null, 1, null, null, null, 1, null,null);
		player2.cooldown = 6;
		team2.Add(player2);

		CombatState state = new CombatState(team1, team2);
		state.timePassed(3);

		Assert.AreEqual(2, player1.cooldown);
		Assert.AreEqual(3, player2.cooldown);
	}
}
