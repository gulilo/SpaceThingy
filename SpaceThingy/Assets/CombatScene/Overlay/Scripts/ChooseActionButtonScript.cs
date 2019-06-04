using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseActionButtonScript : MonoBehaviour
{
	public Ability ability;
	public Vector2 target;

	public void init(Ability ability, Vector2 target)
	{
		this.ability = ability;
		this.target = target;
		transform.GetComponentInChildren<Text>().text = ability.name;
	}

	public void click()
	{
		//CombatManager.Instance.useAbility(CombatManager.Instance.currentPlayer, ability, target, CombatManager.Instance.map);
	}
}
