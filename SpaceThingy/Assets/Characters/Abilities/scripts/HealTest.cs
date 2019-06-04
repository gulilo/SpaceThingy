using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class HealTest
{
	public class UseTest
	{
		Character doer;
		Character getter;
		Heal heal;
		List<Character> targets;

		[SetUp]
		public void before()
		{
			doer = new PlayerCharacter(new Stat(10f), null, null, null, null, 1, new TestWeapon(), null, null, 1, null,null);
			getter = new PlayerCharacter(null, null, null, null, new Stat(200), 50, null, null, null, 1, null,null);
			heal = new Heal();
			targets = new List<Character>();
			targets.Add(getter);
		}

		[Test]
		public void HealAddToCurrentHP()
		{
			heal.use(doer, targets, new TestRoller());

			Assert.AreEqual(85, getter.currentHp);
		}

		[Test]
		public void modiferChangeTheHealing()
		{
			HealModifier healmod;
			healmod = new HealModifier(1.5f);

			heal.mods.add(healmod);

			heal.use(doer, targets, new TestRoller());

			Assert.AreEqual(102.5, getter.currentHp);
		}
	}

	public class CanUseTest
	{
		Character doer;
		Character getter;
		Heal heal;
		List<Character> targets;
		[SetUp]
		public void before()
		{
			doer = new PlayerCharacter(new Stat(49f), null, null, null, null, 1, null, null, null, 1, null,null);
			heal = new Heal();
			targets = new List<Character>();
			targets.Add(getter);
		}

		/*[Test]
		public void getterNotFullHealth()
		{
			getter = new PlayerCharacter(null, null, null, null, new Stat(200), 50, null, null, null);

			bool answer = heal.canUse(doer, getter);

			Assert.IsTrue(answer);
		}

		[Test]
		public void getterIsFullHealth()
		{
			getter = new PlayerCharacter(null, null, null, null, new Stat(200), 200, null, null, null);

			bool answer = heal.canUse(doer, getter);

			Assert.IsFalse(answer);
		}*/
	}


}
