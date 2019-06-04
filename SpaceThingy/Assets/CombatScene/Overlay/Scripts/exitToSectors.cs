using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class exitToSectors : MonoBehaviour {

	public void click()
	{
		SceneManager.LoadScene("sectorMapScene");
	}
}
