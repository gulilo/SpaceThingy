using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "granade", menuName = "items/granade", order = 1)]
public class GrenadeScript : UsableItem
{
	public int damgeBase = 50;
	public int splash = 1;
	public int range = 3;
	public int dmgvar = 10;

	public override bool canUse(Character user, Vector2 target, Inventory inventory)
	{
		bool haveItem = base.canUse(user, target, inventory);
		return haveItem;
	}

	public override void useIt(Character user, Vector2 target, Inventory inventory)
	{
		/*base.useIt(user, target, map, inventory);
		Character getter = map.GetCharacter(target);

		List<Vector2> splashArea = Helper.tilesInRange(target, splash);
		int damgeDealt = Random.Range(damgeBase - dmgvar, damgeBase + dmgvar);

		if (getter != null)
		{
			getter.dealDamage(damgeDealt);
		}
		for (int i = 0; i < splashArea.Count; i++)
		{
			if (map.GetCharacter(splashArea[i]) != null)
			{
				map.getTile(splashArea[i]).character.dealDamage(damgeDealt / 2);
			}
		}*/
	}
}

