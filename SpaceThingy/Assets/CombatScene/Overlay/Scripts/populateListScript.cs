using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class populateListScript : MonoBehaviour
{
	public GameObject buttonPrefab;
	private List<GameObject> buttons;

	void Awake()
	{
		buttons = new List<GameObject>();
	}

	public void populate(List<UsableItem> list)
	{
		clearList();
		List<UsableItem> it = new List<UsableItem>();
		List<int> count = new List<int>(); //maybe use node of item and count insted..
		for(int i = 0; i < list.Count;i++)
		{
			int index;
			if((index = containType(it,list[i])) < 0)
			{
				it.Add(list[i]);
				count.Add(1);
			}
			else
			{
				count[index]++;
			}
		}

		for (int i = 0; i < it.Count; i++)
		{
			GameObject button = Instantiate(buttonPrefab,transform);
			button.transform.localScale = new Vector3(1, 1,1);
			button.GetComponent<InventoryButtonScript>().init(it[i], transform.parent.parent.parent.gameObject);
			button.GetComponentInChildren<Text>().text = it[i].name + "  X" + count[i];
			buttons.Add(button);
		}
	}

	private int containType(List<UsableItem> list, UsableItem item)
	{
		for(int i = 0;i < list.Count;i++)
		{
			if(list[i].name == item.name)
			{
				return i;
			}
		}
		return -1;
	}

	private void clearList()
	{
		for (int i = buttons.Count - 1; i >= 0; i--)
		{
			Destroy(buttons[i]);
		}
	}
}


