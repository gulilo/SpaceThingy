using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Class", menuName = "Class", order = 1)]
public class Job : ScriptableObject
{
    //data
	public int minHP;
	public int maxHP;

	public int minAttack;
	public int maxAttack;
	public int minDefense;
	public int maxDefense;
	public int minSpeed;
	public int maxSpeed;
	public int minCharisma;
	public int maxCharisma;

	public int medicRange;
	
    public Weapon startingWeapon;
	public Armor startingArmor;
	public Special[] startingSpecials;

    public List<Item> startingItems;

	public List<Ability> abilities;

	//rendering

	public Sprite spriteTeam1;
	public Sprite spriteTeam2;
}
    