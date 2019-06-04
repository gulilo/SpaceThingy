using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : Equipable
{
	public override void equip(Character character,Inventory inventory)
	{
		base.equip(character, inventory);
		//character.special = this;
	}

	public override void unequip(Character character,Inventory inventory)
	{
		base.unequip(character, inventory);
		//character.special = null;
	}
}
