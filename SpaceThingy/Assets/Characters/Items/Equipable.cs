using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipable : Item
{
	public ModifierCollection modifiers;

	public virtual void equip(Character character, Inventory inventory)
	{
		for(int i = 0; i < modifiers.count;i++)
		{
			modifiers[i].add(character);
		}
		//inventory.removeItem(this);
	}

	public virtual void unequip(Character character, Inventory inventory)
	{
		for (int i = 0; i < modifiers.count; i++)
		{
			modifiers[i].remove(character);
		}
		//inventory.addItem(this);
	}
}
