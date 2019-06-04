using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ItemFactoryTest
{
	[Test]
	public void getItem()
	{
		ItemFactory factory = ItemFactory.Instance;
		Item target =  Resources.Load("Usables") as Item;

		Item returned = factory.getItem("testItem");

		Assert.AreEqual(returned, target);
	}
}
