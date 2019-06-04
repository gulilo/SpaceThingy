using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Adrenaline", menuName = "items/Adrenaline", order = 1)]
public class Adrenaline : UsableItem
{
	public float multi = 1.2f;
	public int delay = 3; //delay in turns

	public override bool canUse(Character user, Vector2 target, Inventory inventory)
	{
		return false;
	}

	public override void useIt(Character user, Vector2 target, Inventory inventory)
	{
		base.useIt(user, target, inventory);
		Character getter = null;//= map.GetCharacter(target);

		//Buff b = new Buff("adrenaline", getter, delay, activate, deactivate);
		//CombatManager.Instance.addBuff(b);//bad, dont know what to do..
	}

	public void activate(Character c)
	{
		/*c.attack.addModifir(multi);
		c.defense.addModifir(multi);
		c.charisma.addModifir(multi);*/

		Debug.Log("activate adrenalin");
	}

	public void deactivate(Character c)
	{
		/*c.attack.removeModifir(multi);
		c.defense.removeModifir(multi);
		c.charisma.removeModifir(multi);*/

		Debug.Log("deactivate adrenalin");
	}

}
