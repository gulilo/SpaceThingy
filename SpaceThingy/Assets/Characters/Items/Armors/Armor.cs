using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "armor",menuName = "armor", order = 1)]
public class Armor : Equipable
{
	public int armor { get; private set; }

	public override void equip(Character character,Inventory inventory)
	{
		base.equip(character, inventory);
		character.equipArmor(this);
	}

	public override void unequip(Character character,Inventory inventory)
	{
		base.unequip(character, inventory);
		character.equipArmor(null);
	}
}
