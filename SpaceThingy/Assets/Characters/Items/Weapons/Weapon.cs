using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class Weapon : Equipable
{
    public int damgeMin { get; set; }
    public int damgeMax { get; set; }
    
	public override void equip(Character character, Inventory inventory)
	{
		base.equip(character, inventory);
		character.equipWeapon(this);
	}

	public override void unequip(Character character, Inventory inventory)
	{
		base.unequip(character, inventory);
		character.equipWeapon(null);
	}
}
