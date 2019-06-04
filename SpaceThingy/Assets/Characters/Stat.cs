using System.Collections.Generic;
using UnityEngine;

public class Stat
{
	private float baseStat;
	public float value { get { return getValue(); } private set { } }

	public ModifierCollection modifiers;

	public Stat(float baseStat)
	{
		this.baseStat = baseStat;
		modifiers = new ModifierCollection();
	}

	private float getValue()//need to add some kind of priority and stacking.
	{
		float ans = baseStat;
		return modifiers.calc(ans);
	}

	public void addModifir(Modifier mod)
	{
		modifiers.add(mod);
	}

	public void removeModifir(Modifier mod)
	{
		modifiers.remove(mod);
	}
}
