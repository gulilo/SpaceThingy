public abstract class PresModifier : Modifier
{
	public PresModifier(float amount) : base(amount)
	{
		this.amount = amount / 100;
		if (amount > 0)
			this.amount += 1;
		else
			this.amount *= -1;
	}
}