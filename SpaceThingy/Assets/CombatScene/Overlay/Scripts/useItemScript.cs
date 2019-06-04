using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useItemScript : MonoBehaviour
{

	public Vector2 target;

	public void init(Vector2 target)
	{
		this.target = target;
	}

	public void click()
	{
		Character character = CombatManager.Instance.currentPlayer;
		//character.toUse.useIt(character, target, CombatManager.Instance.map, character.inventory);
	}
}
