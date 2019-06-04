using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewGameScript : MonoBehaviour {

	public void click()
	{
		GameManager.Instance.startGame();
	}
}
