using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
	public PlayerCharacter(Job type, int team, string firstName, string lastName, Inventory inventory) : base(type, team, firstName, lastName, inventory)
	{
	}

	public PlayerCharacter(Stat attack, Stat defense, Stat speed, Stat charisma, Stat Hp, float currentHp,Weapon startingWeapon, Armor startingArmor, Special[] startingSpecials,float cooldown,List<Ability> abilities,AttackAbility attackAbility)
		: base(attack, defense, speed, charisma, Hp, currentHp, startingWeapon,startingArmor,startingSpecials, cooldown,abilities, attackAbility)
	{
	}

	public override void doTurn()
	{
	}
}
