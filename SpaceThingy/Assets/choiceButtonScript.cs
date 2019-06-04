using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceButtonScript : MonoBehaviour
{
	public EventOption option;

	public void click()
	{
		if (option != null)
		{
			option.choose();
		}
	}
}
