using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreator
{
	private static EventCreator ins;
	public static EventCreator instance { get { if (ins == null) ins = new EventCreator(); return ins; } private set { } }

	public Event createEvent(string normal, string visited, EventOption[] options)
	{
		Event e = new Event(normal, visited, options);

		return e;
	}

	public Event createEvent()
	{
		EventOption[] options = new EventOption[1];
		options[0] = new EventOption(new StartCombatAction());

		Event e = new Event("normal text", "visited text",options);
		return e;
	}
}
