using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAI : AICharacter
{
	public SniperAI(Job type, int team, string firstName, string lastName, Inventory inventory) : base(type, team, firstName, lastName, inventory)
	{
		//ShotUtility shotutil = new ShotUtility();
		//SteadyAim action = null;
		for (int i = 0; i < type.abilities.Count; i++)
		{
			//if (type.abilities[i] is SteadyAim)
		//	{
		//		action = (SteadyAim)type.abilities[i];
		//	}
		}
	//	shotutil.action = action;
		//utilities.Add(shotutil);
	}

	protected override float calcUtil(Utility u, Character c, Vector2 tile, out Vector2 target)
	{
	//	if (u is ShotUtility && c.loc == tile)
	//	{
	//		u.modifier = 1.5f;
	//	} 
	//	else
	//	{
		//	u.modifier = 1f;
	//	}
		return u.calculate(c, tile, out target);
	}
}
