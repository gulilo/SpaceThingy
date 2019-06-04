using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Ability : ScriptableObject
{
	public float cooldown;
	public float timeLeft;
	public ModifierCollection mods = new ModifierCollection();
	public event EventHandler ready;

	public virtual bool canUse(Character doer, CombatState state)
	{
		return true;
	}

	public virtual void use(Character doer, List<Character> targets, IRoller roller)
	{
		Debug.Log("bbbb");
		timeLeft = cooldown;
	}

	public void passTime(float timePassed, Character doer, IRoller roller)
	{
		timeLeft -= timePassed;
		if(ready != null)
		{
			ready(this, null); 
		}
	}
}
