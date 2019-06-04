using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventShower : MonoBehaviour
{
	public Text text;
	public GameObject panel;
	public GameObject buttonPrefub;

	void Start()
	{
		Event e = EventCreator.instance.createEvent();

		show(e);
	}

	public void show(Event e)
	{
		text.text = e.getText();

		for(int i = 0; i < e.options.Length;i++)
		{
			GameObject b =  Instantiate(buttonPrefub, panel.transform);
			b.GetComponent<choiceButtonScript>().option = e.options[i];
		}
	}
}
