using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPerTime : Ability
{
	public override void use(Character doer, List<Character> targets, IRoller roller)
	{
		timeLeft += cooldown;
	}

	public new void passTime(float timePassed, Character doer, IRoller roller)
	{
		timeLeft -= timePassed;
		while(timeLeft <= 0)
		{			
			use(doer, new List<Character> { doer.target }, roller);
			Debug.Log("in while" + timeLeft);
		}
	}
}
