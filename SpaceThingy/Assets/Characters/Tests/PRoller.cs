using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRoller : IRoller {

	public float get(float x)
    {
        return x;
    }

	public float roll()
	{
		throw new System.NotImplementedException();
	}

	public int rollDice(int sides)
    {
        return Random.Range(1, sides + 1);
    }

    public float rollPara(float max)
    {
        float o = 0.5f;
        float p = 2f;
        float multi = max / Mathf.Pow(o, p);
        float r = Random.Range(0, 1);
        r = Mathf.Pow(r, p);
        return r*multi;
    }
}
