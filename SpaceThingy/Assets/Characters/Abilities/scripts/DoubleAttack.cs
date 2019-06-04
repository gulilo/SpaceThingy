using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttack : Ability
{
	public new bool canUse(Character doer, CombatState state)
    {
		throw new System.NotImplementedException();
	}

	public new void use(Character doer, List<Character> targets, IRoller roller)
    {
		base.use(doer, targets, roller);
        float myRoll = roller.roll();
        float bdmg = doer.weapon.damgeMin + (doer.weapon.damgeMax - doer.weapon.damgeMin) * myRoll;

        bdmg += doer.attack.value;
        bdmg = mods.calc(bdmg);

        targets[0].dealDamage(bdmg / 2 - targets[0].defense.value);
        targets[1].dealDamage(bdmg / 2 - targets[1].defense.value);
    }
}
