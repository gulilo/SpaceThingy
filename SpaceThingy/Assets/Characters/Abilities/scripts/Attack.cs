using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
	public float cooldown = 10f;

	public new void use(Character doer, List<Character> targets, IRoller roller)
	{
		base.use(doer, targets, roller);
        float myRoll = roller.roll();
        float baseDamage = doer.weapon.damgeMin + (doer.weapon.damgeMax - doer.weapon.damgeMin) * myRoll;

        baseDamage += doer.attack.value;
        baseDamage = mods.calc(baseDamage);

        targets[0].dealDamage(baseDamage - targets[0].defense.value);

	}
}
