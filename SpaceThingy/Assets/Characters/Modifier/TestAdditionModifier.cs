internal class TestAdditionModifier : AdditionModifier
{
	
	public TestAdditionModifier(float amount) : base(amount)
	{
	}

	public override void add(Character c)
	{
		throw new System.NotImplementedException();
	}

	public override void remove(Character c)
	{
		throw new System.NotImplementedException();
	}
}