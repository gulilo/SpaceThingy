using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCreatorScript : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public List<Character> createTeam(List<Job> jobs, int team, bool ai)
	{
		List<Character> bla = new List<Character>();
		CharacterCreator cc = CharacterCreator.Instance;

		for (int i = 0; i < jobs.Count; i++)
		{
			Character c = null;
			if(jobs[i].name.Contains("sniper"))
			{
				c = cc.createSniper(team, ai);
			}
			else if (jobs[i].name.Contains("bazerker"))
			{
				c = cc.createBazerker(team, ai);
			}
			else if (jobs[i].name.Contains("medic"))
			{
				c = cc.createMedic(team, ai);
			}
			bla.Add(c);
		}
		
		return bla;
	}
}
