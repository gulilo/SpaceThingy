using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
	private static CharacterCreator ins;
	public static CharacterCreator instance
	{
		get
		{
			if (ins == null)
				ins = new CharacterCreator();
			return ins;
		}
		private set { }
	}

	private Job[] types;

	public CharacterCreator()
	{
		types = loadAssets<Job>("characterTypes");

	}

	private T[] loadAssets<T>(string path) where T : Job
	{
		Object[] test = Resources.LoadAll(path, typeof(T));
		T[] array = new T[test.Length];
		for (int i = 0; i < test.Length; i++)
		{
			array[i] = test[i] as T;
		}
		return array;
	}

	public Character create(Job type, IRoller roller)
	{
		Stat attack = new Stat(rollStat(roller, type.minAttack, type.maxAttack));
		Stat deffnse = new Stat(rollStat(roller, type.minDefense, type.maxDefense));
		Stat speed = new Stat(rollStat(roller,type.minSpeed,type.maxSpeed));
		Stat charisma = new Stat(rollStat(roller, type.minCharisma, type.maxCharisma));
		Stat Hp = new Stat(rollStat(roller, type.minHP, type.maxHP));

		Weapon startingWeapon = type.startingWeapon;
		Armor startingArmor = type.startingArmor;
		Special[] StartingSpecials = type.startingSpecials;

		Character c = new PlayerCharacter(attack, deffnse,speed, charisma, Hp, Hp.value,startingWeapon,startingArmor, StartingSpecials, 1, null,null);
		return c;
	}//refactor later.

	public Character create(Job type, float currentHp, IRoller roller)
	{
		Stat attack = new Stat(rollStat(roller, type.minAttack, type.maxAttack));
		Stat deffnse = new Stat(rollStat(roller, type.minDefense, type.maxDefense));
		Stat speed = new Stat(3);
		Stat charisma = new Stat(rollStat(roller, type.minCharisma, type.maxCharisma));
		Stat Hp = new Stat(rollStat(roller, type.minHP, type.maxHP));

		Weapon startingWeapon = type.startingWeapon;
		Armor startingArmor = type.startingArmor;
		Special[] StartingSpecials = type.startingSpecials;

		Character c = new PlayerCharacter(attack, deffnse,speed, charisma, Hp, currentHp, startingWeapon, startingArmor, StartingSpecials, 1, null,null);
		return c;
	}

	private int rollStat(IRoller roller, int min, int max)
	{
		float rolled = roller.roll();
		return (int)(min + (max-min) * rolled);
	}

	public Job getJob(string type)
	{
		for (int i = 0; i < types.Length; i++)
		{
			if (types[i].name == type)
			{
				return types[i];
			}
		}
		throw new System.Exception("unknown job");
	}



	// --------------------------------UNTESTED ------------------------------------
	public Job medicAsset;
	public Job sniperAsset;
	public Job bazerkerAsset;

	public Material sniper1, sniper2, bes1, bes2, medic1, medic2;
	public GameObject humanPrefab;
	private Inventory[] inv;

	public static CharacterCreator Instance { get; private set; }
	void Start()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		Instance = this;
		inv = new Inventory[2];
		inv[0] = new Inventory();
		inv[1] = new Inventory();
	}

	public Character createSniper(int team, bool ai)
	{
		Character ans;
		if (ai)
		{
			ans = createAICharacter(sniperAsset, team, inv[team]);
		}
		else
		{
			ans = createCharacter(sniperAsset, team, inv[team]);
		}
		return ans;
	}

	public Character createMedic(int team, bool ai)
	{
		Character ans;
		if (ai)
		{
			ans = createAICharacter(medicAsset, team, inv[team]);
		}
		else
		{
			ans = createCharacter(medicAsset, team, inv[team]);
		}
		return ans;
	}

	public Character createBazerker(int team, bool ai)
	{
		Character ans;
		if (ai)
		{
			ans = createAICharacter(bazerkerAsset, team, inv[team]);
		}
		else
		{
			ans = createCharacter(bazerkerAsset, team, inv[team]);
		}
		return ans;
	}


	private Character createCharacter(Job job, int team, Inventory inventory)
	{
		int gander = Random.Range(0, 2);
		string[] name = NameGenerator.Instance.randomName(gander);
		Character c = new PlayerCharacter(job, team, name[0], name[1], inventory);
		return c;
	}

	private Character createAICharacter(Job job, int team, Inventory inventory)
	{
		int gander = Random.Range(0, 2);
		string[] name = NameGenerator.Instance.randomName(gander);
		Character c = null;
		if (job == sniperAsset)
		{
			c = new SniperAI(job, team, name[0], name[1], inventory);
		}
		return c;
	}

	public GameObject createGameObjectCharacter(Character c)
	{
		GameObject obj = Instantiate(humanPrefab);
		c.gameObject = obj;
		obj.GetComponent<CharacterObjectScript>().setCharacter(c);
		obj.GetComponent<healthSliderScript>().init(c);

		return obj;
	}
}
