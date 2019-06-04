using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EventTest
{
	public class Visit
	{
		Event e;
		string normal = "this is the normal text";
		string visited = "this is the visited text";

		[SetUp]
		public void before()
		{	
			e = new Event(normal, visited,null);
		}

		[Test]
		public void normalText()
		{
			Assert.AreEqual(normal, e.getText());
		}

		[Test]
		public void visitEvent()
		{
			e.visit();
			Assert.IsTrue(e.visited);
		}

		[Test]
		public void visitedText()
		{
			e.visit();
			Assert.AreEqual(visited, e.getText());
		}
	}



	public class ChooseOption
	{
		Event e;
		string normal = "this is the normal text";
		string visited = "this is the visited text";

		[SetUp]
		public void before()
		{
			EventOption[] options = new EventOption[] { new EventOption(new StartCombatAction())};

			e = new Event(normal, visited,options);
		}

		[Test]
		public void optionOne()
		{
			e.options[0].choose();

			Assert.IsTrue(e.options[0].chosen);
		}
	}
}
