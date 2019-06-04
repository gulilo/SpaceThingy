using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButtonScript : MonoBehaviour {

	public int number;

	public void click()
	{
		CharacterCriationManager.Instance.changeTab(number);
	}
}
