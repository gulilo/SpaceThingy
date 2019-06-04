using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class StatTest
{
	public class GetValue
	{
		[Test]
		public void withoutModifirsReturnBase()
		{
			Stat stat = new Stat(10);

			Assert.AreEqual(10, stat.value);
		}

		[Test]
		public void withModifire()
		{
			Stat stat = new Stat(10);
			stat.addModifir(new testModifier(5));

			Assert.AreEqual(15, stat.value);
		}

		[Test]
		public void modivireStucking()
		{
			Stat stat = new Stat(10);
			stat.addModifir(new testModifier(5));
			stat.addModifir(new testModifier(5));

			Assert.AreEqual(20, stat.value);
		}

		[Test]
		public void removeModifier()
		{
			Stat stat = new Stat(10);
			Modifier m = new testModifier(5);

			stat.addModifir(m);
			stat.removeModifir(m);

			Assert.AreEqual(10, stat.value);
		}

		private class testModifier : AdditionModifier
		{
			public testModifier(float amount) : base(amount)
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
	}
}
