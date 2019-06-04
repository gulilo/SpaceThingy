using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Character
{
	public Stat attack { get; private set; }
	public Stat defense { get; private set; }
	public Stat speed { get; private set; }
	public Stat charisma { get; private set; }
	public Stat maxHp { get; private set; }
	public float currentHp { get; private set; }

	public Weapon weapon { get; private set; }
	public Armor armor { get; private set; }
	public Special[] specials { get; private set; }

	public float cooldown { get; set; }
	public List<Ability> abilities { get; private set; }

	public AttackAbility attackAbility;
	public Character target;

	public event EventHandler<HpArgs> damageDealt;
	public event EventHandler<HpArgs> heald;
	public event EventHandler died;

	public event EventHandler weaponEquiped;
	public event EventHandler armorEquiped;
	public event EventHandler specialEquiped;

	public Character(Stat attack, Stat defense, Stat speed, Stat charisma, Stat maxHp, float currentHp, Weapon startingWeapon, Armor startingArmor, Special[] startingSpecials, float cooldown, List<Ability> abilities,AttackAbility attackAbility)
	{
		this.attack = attack;
		this.defense = defense;
		this.speed = speed;
		this.charisma = charisma;
		this.maxHp = maxHp;
		this.currentHp = currentHp;

		this.weapon = startingWeapon;
		this.armor = startingArmor;
		this.specials = startingSpecials;

		this.cooldown = cooldown;

		this.abilities = abilities;

		this.attackAbility = attackAbility;
		this.target = null;
	}

	public void heal(float heal)
	{
		float hp = Mathf.Min(currentHp + heal, maxHp.value);
		if (heald != null)
		{
			heald(this, new HpArgs(hp - currentHp));
		}
		currentHp = hp;
	}

	public void dealDamage(float dmg)
	{
		float hp = Mathf.Max(currentHp - dmg, 0);
		if (hp == 0)
		{
			dead();
		}
		if (damageDealt != null)
		{
			damageDealt(this, new HpArgs(currentHp - hp));
		}
		currentHp = hp;
	}

	private void dead()
	{
		if (died != null)
		{
			died(this, null);
		}
	}

	public class HpArgs : EventArgs
	{
		public float amount { get; private set; }

		public HpArgs(float amount)
		{
			this.amount = amount;
		}
	}
	//wrong
	public void equipWeapon(Weapon weapon)
	{
		this.weapon.unequip(this, inventory);
		if (weapon == null)
		{
			ItemFactory.Instance.getWeapon("fist").equip(this, inventory);
		}
		else
		{
			weapon.equip(this, inventory);
		}

		if (weaponEquiped != null)
		{
			weaponEquiped(this, null);
		}
	}

	//no tests
	public void equipArmor(Armor armor)
	{
		if (this.armor != null)
		{
			this.armor.unequip(this, inventory);
		}

		armor.equip(this, inventory);

		if (armorEquiped != null)
		{
			armorEquiped(this, null);
		}
	}

	//no tests
	public void equipSpecial(Special special, int index)
	{
		if (specials[index] != null)
		{
			specials[index].unequip(this, inventory);
		}

		special.equip(this, inventory);
		specials[index] = special;//maybe
		if (specialEquiped != null)
		{
			specialEquiped(this, null);
		}
	}

	public void reduseCooldown(float timePassed, IRoller roller)
	{
		if (abilities != null)
		{
			for (int i = 0; i < abilities.Count; i++)
			{
				abilities[i].passTime(timePassed, this, roller);
			}
		}
		if(attackAbility != null)
		{
			Debug.Log(attackAbility);
			attackAbility.passTime(timePassed, this, roller);
		}
	}



// ------------------------------ UNTESTED --------------------------

public Job type { get; private set; }
public GameObject go;
public GameObject gameObject { get { return go; } set { go = value; } }

public string firstName = "best name";
public string lastName = "last name";

public int iniative;
public int team { get; private set; }

public bool useItem;
public UsableItem toUse;

public List<Buff> buffs;
public Inventory inventory;

public Character(Job type, int team, string firstName, string lastName, Inventory inventory)
{
	this.type = type;
	this.team = team;
	this.firstName = firstName;
	this.lastName = lastName;
	this.inventory = inventory;
	buffs = new List<Buff>();
	init(inventory);
}

private void init(Inventory inventory)
{
	//maxHp = new Stat(type.minHP, type.maxHP);
	currentHp = maxHp.value;
	/*attack = new Stat(type.minBlasting, type.maxBlasting);
	defense = new Stat(type.minCharisma, type.maxCharisma);
	charisma = new Stat(type.minAttack, type.maxAttack);
	twoTiming = new Stat(type.minDefense, type.maxDefense);
	*/
	for (int i = 0; i < type.startingItems.Count; i++)
	{
		inventory.addItem(ItemFactory.Instance.getItem(type.startingItems[i].name));
	}
	if (type.startingWeapon != null)
	{
		weapon = ItemFactory.Instance.getWeapon(type.startingWeapon.name);
	}
	if (type.startingArmor != null)
	{
		armor = ItemFactory.Instance.getArmor(type.startingArmor.name);
	}
	/*if (type.startingSpecial != null)
	{
	//	special = ItemFactory.Instance.GetSpecial(type.startingSpecial.name);
	}*/
}


public void startTurn()
{

}

public void endTurn()
{

}


//dont know how abilities will work in the new combat...
public List<Ability> getAbilities(Vector2 currentSelected)
{
	List<Ability> ans = new List<Ability>();
	for (int i = 0; i < type.abilities.Count; i++)
	{
		/*if (type.abilities[i].canUse(this, currentSelected))
		{
			ans.Add(type.abilities[i]);
		}*/
	}
	return ans;
}

//dont know how abilities will work in the new combat...
public void useAbility(Ability ability, Vector2 location)
{
	//ability.doit(this, location);
	/*if (ability.turnEnding)
	{
		CombatManager.Instance.nextTurn();// can be bad...
	}*/
}

public abstract void doTurn();
}
