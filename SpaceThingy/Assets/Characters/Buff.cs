using System.Collections.Generic;
using System;
using UnityEngine;

public class Buff
{
	public ModifierCollection modifiers;
	public float timer { get; set; }
	private float timeLeft;
	private Character c;

	public Buff(float timer,List<Modifier> mods )
	{
		this.timer = timer;
		timeLeft = this.timer;
		modifiers = new ModifierCollection();
		for(int i = 0; i < mods.Count;i++)
		{
			modifiers.add(mods[i]);
		}
	}

	public void add(Character c)
	{
		this.c = c;

		for(int i = 0;i < modifiers.count;i++)
		{
			modifiers[i].add(c);
		}
	}

	public void remove(Character c)
	{
		for( int i = 0; i < modifiers.count;i++)
		{
			modifiers[i].remove(c);
		}
	}

	//maybe add chack for if started?
	public void moveTime(float timePassed)
	{
		timeLeft -= timePassed;
		if (timeLeft < 0)
		{
			remove(c);
		}
	}
}
