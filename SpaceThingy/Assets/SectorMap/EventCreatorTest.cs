using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EventCreatorTest {

	public class CreateEvent
	{
		[Test]
		public void eventWithOneOption()
		{
			string normal = "this is the normal text";
			string visi = "this is the visited Text";

			EventOptionAction ac = new StartCombatAction();
			EventOption op = new EventOption(ac);
			EventOption[] arr = new EventOption[] { op };

			Event actual = new Event(normal, visi,arr);

			Event created = EventCreator.instance.createEvent(normal, visi, arr);


			Assert.IsTrue(equalsEvent(actual, created));
			//Assert.AreEqual(created, actual);
		}

		[Test]
		public void createRandomEvent()
		{

		}

		private bool equalsEvent(Event e1, Event e2)
		{
			if(e1.text != e2.text)
			{
				return false;
			}
			if(e1.visitedText != e2.visitedText)
			{
				return false;
			}

			if(e1.visited != e2.visited)
			{
				return false;
			}

			if(e1.options.Length != e2.options.Length)
			{
				return false;
			}
			for(int i = 0; i < e1.options.Length;i++)
			{
				if(e1.options[i] != e2.options[i])//will be problematic later....
				{
					return false;
				}
			}

			return true;
		}
	}
}
