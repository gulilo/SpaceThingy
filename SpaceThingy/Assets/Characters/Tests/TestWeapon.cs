public class TestWeapon : Weapon
{
	public TestWeapon()
	{
		Modifier m = new AttackModifier(5);
		modifiers = new ModifierCollection();
		modifiers.add(m);

        damgeMin = 20;
        damgeMax = 30;
	}
}