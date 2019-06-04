using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMainMenu : MonoBehaviour {

	public void click()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
