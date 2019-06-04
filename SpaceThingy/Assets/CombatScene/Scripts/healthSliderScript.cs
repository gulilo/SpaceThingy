using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSliderScript : MonoBehaviour
{
	public Character character;
	public Slider slider;
	public Text text;

	public void init(Character c)
	{
		character = c;
		slider = transform.GetComponentInChildren<Slider>();
		text = transform.GetComponentInChildren<Text>();
		slider.maxValue = (int)character.maxHp.value;
		slider.value = slider.maxValue;
	}

	// Update is called once per frame
	void Update()
	{
		if (character != null && character.currentHp != slider.value)
		{
			slider.value = character.currentHp;
			//text.text ="" + character.hpCurrent;
		}
	}
}
