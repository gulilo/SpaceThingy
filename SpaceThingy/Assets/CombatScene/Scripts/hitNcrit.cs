using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitNcrit : MonoBehaviour
{


	//   private int totalDamge, critD, CritC;
	// critD = Weapon.damge * power (blastin-runing,1/4)
	// critC = Weapon.accuracy/10 + power(blastin-runing,0.8)
	//  totaldamge = weapno.damge * (blastin-runing)
	//  checkifcrit
	//     ifcrit add crit damge
	//     totaldamge = total damge + crit damge
	//  print total damge



	public static int hitNCrit(Character attacker, Character defender)
	{
		/*float totalDamge = 0, hitChance, criticalChance;
		float criticalDamge, damgeBase, hitDamge, attackerBB = 0;
		Weapon attackerWeapon = attacker.weapon;
		if (attackerWeapon.weaponType == 0)
		{ // melee

			attackerBB = attacker.defense.value;

		}
		if (attackerWeapon.weaponType == 1)
		{//projectile

			attackerBB = attacker.attack.value;
		}
		damgeBase = (int)(Random.Range(attackerWeapon.damgeMin, attackerWeapon.damgeMax + 1));
		if (attackerBB - defender.charisma.value >= 0)
		{
			criticalChance = attackerWeapon.criticalChance + Mathf.Pow(Mathf.Abs((attackerBB - defender.charisma.value)), 0.8f);
		}
		else
		{
			criticalChance = attackerWeapon.criticalChance - Mathf.Pow(Mathf.Abs((attackerBB - defender.charisma.value)), 0.8f);
		}
		criticalDamge = (int)(damgeBase * Mathf.Pow((attackerBB - defender.charisma.value), 1 / 4));
		hitDamge = (int)(damgeBase + Mathf.Pow(attackerBB - defender.charisma.value, 1 / 2));
		hitChance = attackerWeapon.accuracy + attackerBB - defender.charisma.value;
		if (Random.Range(0, 100) < hitChance) { totalDamge = hitDamge; }
		if (Random.Range(0, 100) < criticalChance) { totalDamge = totalDamge + criticalDamge; }*/
		return 7;
	}
}
