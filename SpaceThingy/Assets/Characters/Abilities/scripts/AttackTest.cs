using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class AttackTest
{
	public class CanUseTest
	{

	}

	public class UseTest
	{
		Character doer;
		Character getter;
		Attack atk;
		List<Character> targets;

		[SetUp]
		public void before()
		{
			doer = new PlayerCharacter(new Stat(5f), null, null, null, null, 1, new TestWeapon(), null, null,1,null,null);
			getter = new PlayerCharacter(null, new Stat(3f), null, null, new Stat(200), 100, null, null, null, 1, null,null);
			atk = new Attack();
			targets = new List<Character>();
			targets.Add(getter);
		}

		[Test]
		public void didAttackDidDamge()
		{
			atk.use(doer, targets, new TestRoller());

			Assert.AreEqual(73, getter.currentHp);
		}

		[Test]
		public void didAttackDidDamgeWithModifier()
		{
			AttackModifier atkmod = new AttackModifier(2);
			atk.mods.add(atkmod);

			atk.use(doer, targets, new TestRoller());

			Assert.AreEqual(71, getter.currentHp);
		}
	}
}

