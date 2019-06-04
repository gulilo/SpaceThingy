using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelScript : MonoBehaviour
{
	public void click()
	{
		CombatManager.Instance.currentPlayer.toUse = null;
		CombatManager.Instance.currentPlayer.useItem = false;
		CombatManager.Instance.populateAbilities(null, new Vector2(), null);
	}
}
