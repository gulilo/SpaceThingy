using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teamNumber : MonoBehaviour
{
	Dropdown dd;
	public List<GameObject> chars;
	public GameObject mainPanel;

	// Use this for initialization
	void Start()
	{
		dd = gameObject.GetComponent<Dropdown>();
		dd.onValueChanged.AddListener(bla);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void bla(int index)
	{
		for(int i = 0; i < chars.Count;i++)
		{
			chars[i].SetActive(false);
		}
		for( int i = 0; i < index;i++)
		{
			chars[i].SetActive(true);
		}
	}
}
