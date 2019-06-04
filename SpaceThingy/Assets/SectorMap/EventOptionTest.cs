using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EventOptionTest
{
	public class choosse
	{
		[Test]
		public void combatAction()
		{
			EventOptionAction action = new StartCombatAction();

			EventOption e = new EventOption(action);
			e.choose();
			LogAssert.Expect(LogType.Log, "combat started");
		}

		[Test]
		public void choosenEvent()
		{
			EventOptionAction action = new StartCombatAction();

			EventOption e = new EventOption(action);
			bool choosen = false;
			e.choosen += (sender, args) => choosen = true;

			e.choose();

			Assert.IsTrue(choosen);
		}
	}

	public class ActivateAndDeActivate
	{
		[Test]
		public void activateOption()
		{
			EventOptionAction action = new StartCombatAction();
			EventOption option = new EventOption(action);
			option.activate();
			Assert.IsTrue(option.active);
		}

		[Test]
		public void deactiveOption()
		{
			EventOptionAction action = new StartCombatAction();
			EventOption option = new EventOption(action);
			option.deActivate();
			Assert.IsFalse(option.active);
		}
	}
}
