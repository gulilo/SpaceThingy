using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class GroupHealTest
{
	public class useTest
	{
		PlayerCharacter doer;
		PlayerCharacter getter1;
		PlayerCharacter getter2;

		GroupHeal gHeal;

		List<Character> targets;

		[SetUp]
		public void before()
		{
			doer = new PlayerCharacter(new Stat(10), null, null, null, new Stat(100), 30, new TestWeapon(), null, null, 1, null,null);
			getter1 = new PlayerCharacter(new Stat(10), null, null, null, new Stat(150), 40, null, null, null, 1, null,null);
			getter2 = new PlayerCharacter(new Stat(10), null, null, null, new Stat(200), 50, null, null, null, 1, null,null);

			gHeal = new GroupHeal();

			targets = new List<Character>();
			targets.Add(doer);
			targets.Add(getter1);
			targets.Add(getter2);
		}

		[Test]
		public void DidItHealAllGroup()
		{
			gHeal.use(doer, targets, new TestRoller());

			Assert.AreEqual(47.5, doer.currentHp);
			Assert.AreEqual(57.5, getter1.currentHp);
			Assert.AreEqual(67, 5, getter2.currentHp);
		}
	}
}
