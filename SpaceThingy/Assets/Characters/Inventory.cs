using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
	private List<Item> inv;

	public Inventory()
	{
		inv = new List<Item>();
	}

	public int size()
	{
		return inv.Count;
	}

	public void addItem(Item it)
	{
		inv.Add(it);
	}

	//use [] to get item.
	public Item this[int key]
	{
		get
		{
			return inv[key];
		}
	}

	public Item getItem(Item it)
	{
		return inv.Find(thing => thing.ToString() == it.ToString());
	}

	public void removeItem(Item it)
	{
		inv.Remove(it);
	}

	public bool contain(Item it)
	{
		for(int i = 0; i < inv.Count;i++)
		{
			if(inv[i] == it)
			{
				return true;
			}
		}
		return false;
	}


	private List<T> getT<T>()
		where T : Item
	{
		List<T> ans = new List<T>();

		for (int i = 0; i < inv.Count; i++)
		{
			if (inv[i] is T)
			{
				ans.Add((T)inv[i]);
			}
		}
		return ans;
	}

	public List<UsableItem> getUsalbeItems()
	{
		return getT<UsableItem>();
	}

	public List<Equipable> getEquipables()
	{
		return getT<Equipable>();
	}

	public List<Weapon> getWeapons()
	{
		return getT<Weapon>();
	}

	public List<Armor> getArmors()
	{
		return getT<Armor>();
	}

	public List<Special> getSpecials()
	{
		return getT<Special>();
	}
}
