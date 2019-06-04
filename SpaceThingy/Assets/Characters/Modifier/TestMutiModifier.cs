public class TestMutiModifier : MultiModifier
{
	public TestMutiModifier(float amount) : base(amount)
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