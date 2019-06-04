using NUnit.Framework;

public class CharacterTest
{
	public class DealDamageTest
	{
		Character player;

		[SetUp]
		public void before()
		{
			player = CharacterCreator.instance.create(CharacterCreator.instance.getJob("Test"), new TestRoller());
		}

		[TearDown]
		public void after()
		{
			player = null;
		}

		[Test]
		public void dealSomeDamage()
		{
			player.dealDamage(10);

			Assert.AreEqual(0, player.currentHp);
		}

		[Test]
		public void overkill()
		{
			player.dealDamage(30);

			Assert.AreEqual(0, player.currentHp);
		}

		[Test]
		public void damageDealtEvent()
		{
			float dmgdealt = -1;
			player.damageDealt += (sender, args) => { dmgdealt = args.amount; };
			player.dealDamage(10);

			Assert.AreEqual(10, dmgdealt);
		}

		[Test]
		public void damageDealtEventOverkill()
		{
			float dmgdealt = -1;
			player.damageDealt += (sender, args) => { dmgdealt = args.amount; };
			player.dealDamage(30);

			Assert.AreEqual(10, dmgdealt);
		}

	}

	public class HealTest
	{
		Character player;

		[SetUp]
		public void before()
		{
			player = CharacterCreator.instance.create(CharacterCreator.instance.getJob("Test"),5, new TestRoller());
		}

		[TearDown]
		public void after()
		{
			player = null;
		}

		[Test]
		public void healSomeDamage()
		{
			player.heal(5);

			Assert.AreEqual(10, player.currentHp);
		}

		[Test]
		public void overHeal()
		{
			player.heal(20);

			Assert.AreEqual(10, player.currentHp);
		}

		[Test]
		public void healdEvent()
		{
			float heald = -1;
			player.heald += (sender, args) => { heald = args.amount; };
			player.heal(5);

			Assert.AreEqual(5,heald);
		}

		[Test]
		public void healdEventOverHeal()
		{
			float heald = -1;
			player.heald += (sender, args) => { heald = args.amount; };
			player.heal(20);

			Assert.AreEqual(5, heald);
		}

		
	}

	public class Equipment
	{
		Character player;
		Weapon weapon;

		[SetUp]
		public void before()
		{
			player = CharacterCreator.instance.create(CharacterCreator.instance.getJob("Test"), new TestRoller());
			//player.weapon = new TestWeapon();
			weapon = new TestWeapon();
		}

		[Test]
		public void equipWepon()
		{
			player.equipWeapon(weapon);

			Assert.AreEqual(weapon, player.weapon);
		}

		[Test]
		public void unEquipWeapon()
		{
			Weapon w2 = new TestWeapon();
			player.equipWeapon(weapon);
			player.equipWeapon(w2);

			Assert.AreEqual(w2, player.weapon);
		}

		[Test]
		public void equipingModifiers()
		{
			player.equipWeapon(weapon);

			Assert.Contains(weapon.modifiers[0], player.attack.modifiers.list);
		}

		[Test]
		public void unEquipingRemoveModifiers()
		{
			player.equipWeapon(weapon);

			Weapon w2 = new TestWeapon();
			player.equipWeapon(w2);

			bool b = player.attack.modifiers.list.Contains(weapon.modifiers[0]);
			Assert.IsFalse(b);
		}
	}

	public class ReduseCooldown
	{
		[Test]
		public void notGoingBelowZero()
		{
			Character c = new PlayerCharacter(null, null, null, null, null, 1, null, null, null,5,null,null);

			c.reduseCooldown(10,new TestRoller());

			Assert.AreEqual(0, c.cooldown);
		}

		/*[Test]
		public void readyEventFire()
		{
			Character c = new PlayerCharacter(null, null, null, null, null, 1, null, null, null, 5, null,null);
			bool ready = false;
			c.ready += (sender, args) => { ready = true; };
			c.reduseCooldown(10);

			Assert.IsTrue(ready);
		}*/
	}
}
