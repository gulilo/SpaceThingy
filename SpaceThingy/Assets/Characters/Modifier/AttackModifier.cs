using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModifier : AdditionModifier
{
	public AttackModifier(float amount) : base(amount)
	{
	}

	public override void add(Character c)
	{
		c.attack.addModifir(this);
	}

	public override void remove(Character c)
	{
		c.attack.removeModifir(this);
	}
}
