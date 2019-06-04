using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CharacterCreatorTest
{

	public class Create
	{
		[Test]
		public void CharacterfromType()
		{
			CharacterCreator cc = CharacterCreator.instance;
			Character actual = cc.create(cc.getJob("Test"), new TestRoller());

			Assert.AreEqual(10, actual.currentHp);
		}

		[Test]
		public void currenthpChange()
		{
			CharacterCreator cc = CharacterCreator.instance;
			Character actual = cc.create(cc.getJob("Test"),5, new TestRoller());

			Assert.AreEqual(5, actual.currentHp);
		}

		/*private bool CharacterEquals(Character c1, Character c2)
		{
			if(c1.maxHp.value != c2.maxHp.value)
			{
				return false;
			}
			if(c1.currentHp != c2.currentHp)
			{
				return false;
			}


			return true;
		}*/
	}

	/*public class GetJob
	{
		[Test]
		public void getSniper()
		{
			Job expected = Resources.Load("CharacterTypes/Sniper") as Job;

			Job actual = CharacterCreator.instance.getJob("Sniper");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void unknowedJob()
		{
			//chack how to test exceptions
			Assert.Fail();
		}
	}*/


}
