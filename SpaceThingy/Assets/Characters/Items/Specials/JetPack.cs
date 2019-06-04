using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "JetPack", menuName = "Special/JetPack", order = 1)]
public class JetPack : Special
{
	public override void equip(Character character, Inventory inventory)
	{
		base.equip(character, inventory);
		//TODO write later....
	}

	public override void unequip(Character character, Inventory inventory)
	{
		base.unequip(character, inventory);
		//TODO write later...
	}
}
