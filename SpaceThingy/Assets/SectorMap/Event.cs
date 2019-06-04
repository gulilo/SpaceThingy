using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
	public string text;
	public string visitedText;

	public bool visited = false;

	public EventOption[] options;

	public Event(string text, string visitedText, EventOption[] options)
	{
		this.text = text;
		this.visitedText = visitedText;
		this.options = options;
	}


	public void visit()
	{
		visited = true;
	}

	public string getText()
	{
		if (visited)
		{
			return visitedText;
		}
		return text;
	}
}
