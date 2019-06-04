using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupHeal : Ability {

    public new bool canUse(Character doer, CombatState state)
    {
        throw new System.NotImplementedException();
    }

    public new void use(Character doer, List<Character> targets, IRoller roller)
    {
		base.use(doer, targets, roller);
		float myRoll = roller.roll();
        float baseHeal = doer.weapon.damgeMin + (doer.weapon.damgeMax - doer.weapon.damgeMin) * myRoll;

        baseHeal += doer.attack.value;
        baseHeal = mods.calc(baseHeal);

        for (int i =0; i < targets.Count; i++)
        {
            targets[i].heal(baseHeal / 2);//2 will be something else
        }
    }

}
