using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierCollection
{
	public List<Modifier> list;
	public int indexAddition, indexMulti, indexPres;

	public int count { get { return list.Count; } }

	public ModifierCollection()
	{
		list = new List<Modifier>();
		indexAddition = indexMulti = indexPres = 0;
	}


	public void add(Modifier modifier)
	{
		if (modifier is AdditionModifier)
		{
			list.Insert(indexAddition, modifier);
			indexAddition++;
			indexMulti++;
			indexPres++;
		}
		else if (modifier is PresModifier)
		{
			list.Insert(indexPres, modifier);
			indexPres++;
			indexMulti++;
		}
		else if (modifier is MultiModifier)
		{
			list.Insert(indexMulti, modifier);
			indexMulti++;
		}
		else
		{
			throw new System.Exception("unsoported modifier");
		}
	}

	public void remove(Modifier modifier)
	{
		if (list.Remove(modifier))
		{
			if (modifier is AdditionModifier)
			{
				indexAddition--;
				indexMulti--;
				indexPres--;
			}
			else if (modifier is PresModifier)
			{
				indexMulti--;
				indexPres--;
			}
			else if (modifier is MultiModifier)
			{
				indexMulti--;
			}
		}
	}

	public float calc(float start)
	{
		float ans = start;
		float a = calcAdd();
		ans += a;
		a = clacPres();
		if (a != 0)
			ans *= a;// negetive numbers
		a = calcMul();
		if (a != 1)
			ans *= a;

		return ans;
	}

	private float calcAdd()
	{
		float a = 0;
		for (int i = 0; i < indexAddition; i++)
		{
			a += list[i].amount;
		}
		return a;
	}

	private float clacPres()
	{
		float a = 0;
		for (int i = indexAddition; i < indexPres; i++)
		{
			a += list[i].amount;
		}
		return a;
	}

	private float calcMul()
	{
		float a = 1;
		for (int i = indexPres; i < indexMulti; i++)
		{
			a *= list[i].amount;
		}
		return a;
	}

	public Modifier this[int index]
	{
		get { return list[index]; }
	}

	public bool contain(Modifier modifier)
	{
		return list.Contains(modifier);
	}
}
