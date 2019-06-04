using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScript : MonoBehaviour
{
	public void click()
	{
		GameManager.Instance.continueGame();
	}
}
