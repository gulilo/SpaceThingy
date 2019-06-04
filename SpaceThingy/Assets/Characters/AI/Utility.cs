using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Utility : ScriptableObject
{
	public Ability action;
	public float modifier = 1f;

	//return a number between 0 to 1.
	public abstract float calculate(Character doer, Vector2 location, out Vector2 target);
}
 