using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsableItem : Item
{
	public bool endTurn;

	public virtual bool canUse(Character user, Vector2 target,Inventory inventory)
	{
		return inventory.contain(user.toUse);
	}

	public virtual void useIt(Character user, Vector2 target,Inventory inventory)
	{
		inventory.removeItem(user.toUse);
	}
}
