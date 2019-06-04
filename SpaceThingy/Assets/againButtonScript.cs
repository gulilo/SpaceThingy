using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class againButtonScript : MonoBehaviour
{
	public GameObject panel;
	GameObject parentPanel;

	// Use this for initialization
	void Start()
	{
		parentPanel = transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void click()
	{
		panel.SetActive(true);

		Team t = CombatManager.Instance.state.getTeam(0);
		for (int i = 0; i < t.characters.Count; i++)
		{
			Destroy(t.characters[i].gameObject);
		}

		t = CombatManager.Instance.state.getTeam(1);
		for (int i = 0; i < t.characters.Count; i++)
		{
			Destroy(t.characters[i].gameObject);
		}
		parentPanel.SetActive(false);
	}
}
