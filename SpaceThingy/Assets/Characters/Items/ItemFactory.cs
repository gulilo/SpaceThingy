using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory
{
	private static ItemFactory ins;
	public static ItemFactory Instance {
		get
		{
			if (ins == null)
				ins = new ItemFactory();
			return ins;
		}
		private set { } }

	public string usablePath = "Usables", weaponPath= "Weapons", armorPath= "Armors", SpecialPath= "spacials";

	private UsableItem[] usablesAssets;
	private Weapon[] weaponsAssets;
	private Armor[] armorsAssets;
	private Special[] specialsAssets;
	private Item[] itemsAssets;

	public ItemFactory()
	{
		usablesAssets = loadAssets<UsableItem>(usablePath);
		weaponsAssets = loadAssets<Weapon>(weaponPath);
		armorsAssets = loadAssets<Armor>(armorPath);
		specialsAssets = loadAssets<Special>(SpecialPath);

		itemsAssets = new Item[usablesAssets.Length + armorsAssets.Length + weaponsAssets.Length + specialsAssets.Length];
		int index = 0;
		for (int i = 0; i < usablesAssets.Length; i++)
		{
			itemsAssets[index++] = usablesAssets[i];
		}
		for (int i = 0; i < armorsAssets.Length; i++)
		{
			itemsAssets[index++] = armorsAssets[i];
		}
		for (int i = 0; i < weaponsAssets.Length; i++)
		{
			itemsAssets[index++] = weaponsAssets[i];
		}
		for (int i = 0; i < specialsAssets.Length; i++)
		{
			itemsAssets[index++] = specialsAssets[i];
		}
	}

	private T[] loadAssets<T>(string path) where T : Item
	{
		Object[] test = Resources.LoadAll(path, typeof(T));
		T[] array = new T[test.Length];
		for (int i = 0; i < test.Length; i++)
		{
			array[i] = test[i] as T;
		}
		return array;
	}


	private T get<T>(string name, T[] array) where T : Item
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].name == name)
			{
				T it = GameObject.Instantiate(array[i]);
				it.name = name;
				return it;
			}
		}
		return null;
	}

	public UsableItem getUsableItem(string name)
	{
		return get(name, usablesAssets);
	}

	public Weapon getWeapon(string name)
	{
		return get(name, weaponsAssets);
	}

	public Armor getArmor(string name)
	{
		return get(name, armorsAssets);
	}

	public Special GetSpecial(string name)
	{
		return get(name, specialsAssets);
	}

	public Item getItem(string name)
	{
		return get(name, itemsAssets);
	}
}
