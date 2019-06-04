using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier
{
	public float amount;

	public Modifier(float amount)
	{
		this.amount = amount;
	}

	public abstract void add(Character c);
	public abstract void remove(Character c);
}
