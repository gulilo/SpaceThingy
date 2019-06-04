using System;

internal class HealModifier : MultiModifier
{
	public HealModifier(float amount) : base(amount)
	{
	}

	public override void add(Character c)
	{
		throw new NotImplementedException();
	}

	public override void remove(Character c)
	{
		throw new NotImplementedException();
	}
}