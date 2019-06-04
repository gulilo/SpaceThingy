using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState
{
	private List<Character> team1;
	private List<Character> team2;

	public CombatState(List<Character> team1, List<Character> team2)
	{
		this.team1 = team1;
		this.team2 = team2;
	}

	public void timePassed(float timePassed)
	{
		for(int i = 0; i < team1.Count;i++)
		{
			team1[i].reduseCooldown(timePassed,new PRoller());
		}

		for (int i = 0; i < team2.Count; i++)
		{
			team2[i].reduseCooldown(timePassed, new PRoller());
		}
	}


	// ---------------------------UNTESTED---------------------------------

	public List<Character> characters;

	public Team[] teams;
	public Character currentPlayer;
	public int turn;


	public CombatState(List<Character> team1, List<Character> team2, int turn)
	{
		characters = new List<Character>();
		teams = new Team[2];
		teams[0] = new Team();
		teams[1] = new Team();

		for (int i = 0; i < team1.Count; i++)
		{
			characters.Add(team1[i]);
			teams[0].addCharacter(team1[i]);
		}
		for (int i = 0; i < team2.Count; i++)
		{
			characters.Add(team2[i]);
			teams[1].addCharacter(team2[i]);
		}
		this.turn = turn % characters.Count;
		currentPlayer = characters[turn];
	}

	

	public Team getTeam(int team)
	{
		return teams[team];
	}

	private void rolliniative()
	{
		for (int i = 0; i < characters.Count; i++)
		{
			characters[i].iniative = UnityEngine.Random.Range(0, 10);
		}
		characters.Sort((c1, c2) => c1.iniative.CompareTo(c2.iniative));
	}

	public void characterDied(Character c)
	{
		characters.Remove(c);
		if (teams[0].contain(c))
		{
			teams[0].kill(c);
			if (teams[0].alives == 0)
			{
				CombatManager.Instance.gameOver();
			}
		}
		else if (teams[1].contain(c))
		{
			teams[1].kill(c);
			if (teams[1].alives == 0)
			{
				CombatManager.Instance.win();
			}
		}

		if (c == currentPlayer)
		{
			nextTurn();
		}
	}

	public void nextTurn()
	{
		if(!CombatManager.Instance.running)
		{
			return;
		}
		turn = (turn + 1) % characters.Count;
		currentPlayer.endTurn();
		currentPlayer = characters[turn];
		currentPlayer.startTurn();

		/*for (int i = currentPlayer.buffs.Count - 1; i >= 0; i--)
		{
			if (currentPlayer.buffs[i].onTimer)
			{
				Buff b = currentPlayer.buffs[i];
				b.tickTimer();
				CombatManager.Instance.updateBuffPanel(b);
			}
		}*/
	}
}

