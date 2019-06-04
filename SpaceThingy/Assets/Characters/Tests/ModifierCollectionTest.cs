using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ModifierCollectionTest
{
	public class AddTest
	{
		ModifierCollection collection;
		TestAdditionModifier add;
		TestMutiModifier mul;
		TestPresModifier pres;

		[SetUp]
		public void before()
		{
			collection = new ModifierCollection();
			mul = new TestMutiModifier(2);
			add = new TestAdditionModifier(5);
			pres = new TestPresModifier(50);
		}

		[Test]
		public void addingAddition()
		{
			collection.add(add);

			Assert.AreEqual(add, collection[0]);
		}

		[Test]
		public void addingAdditionAfterMulti()
		{
			collection.add(mul);
			collection.add(add);

			Assert.AreEqual(add, collection[0]);
		}

		[Test]
		public void addingAdditionAfterPres()
		{
			collection.add(pres);
			collection.add(add);

			Assert.AreEqual(add, collection[0]);
		}

		[Test]
		public void addingMulti()
		{
			collection.add(mul);

			Assert.AreEqual(mul, collection[0]);
		}

		[Test]
		public void addingMultiAfterAddition()
		{
			collection.add(add);
			collection.add(mul);

			Assert.AreEqual(mul, collection[1]);
		}

		[Test]
		public void addingMultiAfterPres()
		{
			collection.add(pres);
			collection.add(mul);

			Assert.AreEqual(mul, collection[1]);
		}

		[Test]
		public void addingPres()
		{
			collection.add(pres);

			Assert.AreEqual(pres, collection[0]);
		}

		[Test]
		public void addingPresAfterAddition()
		{
			collection.add(add);
			collection.add(pres);

			Assert.AreEqual(pres, collection[1]);
		}

		[Test]
		public void addingPresAfterMulti()
		{
			collection.add(mul);
			collection.add(pres);

			Assert.AreEqual(pres, collection[0]);
		}

		[Test]
		public void addingPresAfterAdditionAndMulti()
		{
			collection.add(add);
			collection.add(mul);
			collection.add(pres);

			Assert.AreEqual(pres, collection[1]);
			Assert.AreEqual(mul, collection[2]);
			Assert.AreEqual(add, collection[0]);
		}
	}

	public class removeTest
	{
		//write later
	}

	public class ClacTest
	{
		ModifierCollection collection;
		float stat;

		[SetUp]
		public void before()
		{
			collection = new ModifierCollection();
			stat = 5;
		}

		[Test]
		public void noModifier()
		{
			float ans = collection.calc(stat);

			Assert.AreEqual(5, ans);
		}

		[Test]
		public void AdditionModifier()
		{
			TestAdditionModifier add = new TestAdditionModifier(5);

			collection.add(add);

			float ans = collection.calc(stat);
			Assert.AreEqual(10, ans);
		}

		[Test]
		public void MulModifier()
		{
			TestMutiModifier mul = new TestMutiModifier(2);
			collection.add(mul);

			float ans = collection.calc(stat);

			Assert.AreEqual(10, ans);
		}
		[Test]
		public void presModifier()
		{
			TestPresModifier pres = new TestPresModifier(50);
			collection.add(pres);
			float ans = collection.calc(stat);
			Assert.AreEqual(7.5, ans);
		}

		[Test]
		public void negetivePresModifier()
		{
			TestPresModifier pres = new TestPresModifier(-50);
			collection.add(pres);
			float ans = collection.calc(stat);
			Assert.AreEqual(2.5, ans);
		}

		[Test]
		public void allModifier()
		{
			TestAdditionModifier add = new TestAdditionModifier(5);
			TestMutiModifier mul = new TestMutiModifier(2);
			TestPresModifier pres = new TestPresModifier(50);

			collection.add(add);
			collection.add(mul);
			collection.add(pres);

			float ans = collection.calc(stat);

			Assert.AreEqual(30, ans);
		}
	}
}
