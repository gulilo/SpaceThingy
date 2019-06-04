using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOption
{
	public bool active;
	public bool chosen = false;
	private EventOptionAction action;

	public event EventHandler choosen;

	public EventOption(EventOptionAction action)
	{
		this.action = action;
	}

	public void activate()
	{
	
		active = true;
		
	}

	public void deActivate()
	{

		active = false;
	}

	public void choose()
	{
		if(choosen != null)
		{
			choosen(this, null);
		}
		chosen = true;

		doAction();
	}

	private void doAction()
	{
		action.doAction();
	}
}
