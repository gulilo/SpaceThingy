using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class TestDoubleAttack
{
	public class useTest
	{
		Character doer;
		Character getter1, getter2;
		DoubleAttack datk;
		List<Character> targets;

		[SetUp]
		public void before()
		{
			doer = new PlayerCharacter(new Stat(5f), null, null, null, null, 1, new TestWeapon(), null, null, 1, null,null);
			getter1 = new PlayerCharacter(null, new Stat(3f), null, null, new Stat(200), 100, null, null, null, 1, null,null);
			getter2 = new PlayerCharacter(null, new Stat(3f), null, null, new Stat(200), 70, null, null, null, 1, null,null);
			datk = new DoubleAttack();
			targets = new List<Character>();
			targets.Add(getter1);
			targets.Add(getter2);
		}

		[Test]
		public void doubleAttackDoesDamage()
		{
			datk.use(doer, targets, new TestRoller());

			Assert.AreEqual(88, getter1.currentHp);
			Assert.AreEqual(58, getter2.currentHp);
		}
	}

	public class canUseTest
	{

	}
}
