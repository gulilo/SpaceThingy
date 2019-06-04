
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "medkit", menuName = "items/medkit", order = 1)]
public class MedKitScript : UsableItem
{
	public float healBase = 30;
	public float healvariation = 5;

	public override bool canUse(Character user, Vector2 target,Inventory inventory)
	{
		return false;
	}

	public override void useIt(Character user, Vector2 target, Inventory inventory)
	{
		base.useIt(user, target, inventory);
		Character getter = null;// map.GetCharacter(target);
		healBase = Random.Range(healBase - healvariation, healBase + healvariation);
		getter.heal(healBase);
	}

}
