using System.Collections.Generic;
using UnityEngine;
public class TestShot : AttackAbility
{
	public TestShot(float time)
	{
		cooldown = time;
		timeLeft = cooldown;
	}

	public override void use(Character doer, List<Character> targets, IRoller roller)
	{
		Debug.Log("bla");
		base.use(doer, targets, roller);
		for( int i = 0; i < targets.Count;i++)
		{
			targets[i].dealDamage(10);
		}
	}
}