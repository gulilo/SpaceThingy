using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScript : MonoBehaviour {
	public void click()
	{
		SceneManager.LoadScene("sectorMapScene");
	}
}
