using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AICharacter : Character
{
	Vector2 moveLocation;
	Ability actionToDo;
	Vector2 actionTarget;

	public List<Utility> utilities;
	//public Utility moveUtility;

	public List<float> calculated;

	public AICharacter(Job type, int team, string firstName, string lastName, Inventory inventory) : base(type, team, firstName, lastName, inventory)
	{
		utilities = new List<Utility>();
		//moveUtility = new MoveUtility();
		//moveUtility.action = getMoveAbility();
	}

	public List<float> calculateUtilities(int num, out List<Vector2> targets)
	{
		Utility u;
		if (num == -1)
		{
			//u = moveUtility; 
		}
		else
		{
			u = utilities[num];
		}

		List<float> list = new List<float>();
		targets = new List<Vector2>();
		/*List<Vector2> tiles = Helper.tilesInRange(loc, movmentLeft);
		Vector2 target = new Vector2();

		for (int i = 0; i < tiles.Count; i++)
		{
			list.Add(calcUtil(u, this, tiles[i],map, out target));
			targets.Add(target);
		}*/
		return list;
	}

	public void chooseAction()
	{
		List<Vector2> tiles = null;//Helper.tilesInRange(loc, 3);

		Vector2 move = new Vector2();
		Ability action = null;
		Vector2 target = new Vector2();
		float best = 0;

		//Move moveAbility = getMoveAbility();

		Ability ability = null;
		float max = 0;
		Vector2 t = new Vector2();

		//for each tile
		for (int i = 0; i < tiles.Count; i++)
		{
			//calculate move utility 
		//	if (moveAbility.canUse(this, tiles[i], map))
		//	{
				ability = null;
				max = calculateForThisTile(tiles[i], out ability, out t);
				Debug.Log("bbbbbb" + t);
				if (max > best)
				{
					move = tiles[i];
					action = ability;
					target = t;
					best = max;
				}
		//	}
		}

		ability = null;
	//	max = calculateForThisTile(loc,map, out ability, out t);
		if (max > best)
		{
		//	move = loc;
			action = ability;
			target = t;
			best = max;
		}
		
		moveLocation = move;
		actionToDo = action;
		actionTarget = target;
	}

	private float calculateForThisTile(Vector2 tile, out Ability action, out Vector2 target)
	{
		Vector2 t = new Vector2();
	//	float moveUtil = calcUtil(moveUtility, this, tile,map, out t);

		//calculate max of actions utilities.
		float max = 0;
		Ability ability = null;
		for (int j = 0; j < utilities.Count; j++)
		{
			float cur = calcUtil(utilities[j], this, tile, out t);
			if (cur > max)
			{
				max = cur;
				ability = utilities[j].action;
			}
		}
		if (max < 0.0001)
		{
			action = null;
		}
		else
		{
			action = ability;
		}
		target = t;
		return max;// * moveUtil;
	}

	protected abstract float calcUtil(Utility u, Character c, Vector2 tile, out Vector2 target);

	/*public Move getMoveAbility()
	{
		for (int i = 0; i < type.abilities.Count; i++)
		{
			if (type.abilities[i] is Move)
			{
				return (Move)type.abilities[i];
			}
		}
		return null;
	}*/

	public override void doTurn()
	{
		chooseAction();
		//useAbility(getMoveAbility(), moveLocation, map); // move
		if (actionToDo != null)//if there is action to do
		{
			Debug.Log(actionToDo + "   " + actionTarget);
			useAbility(actionToDo, actionTarget); // use action
		}
		else
		{
			//CombatManager.Instance.nextTurn();
		}
	}
}
