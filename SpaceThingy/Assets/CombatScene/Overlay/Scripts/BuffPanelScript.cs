using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffPanelScript : MonoBehaviour {

	/*public GameObject buffPanelPrefab;
	private List<GameObject> buffsObject;
	private List<Buff> buffs;

	void Start()
	{
		buffsObject = new List<GameObject>();
		buffs = new List<Buff>();
	}

	public void addBuff(Buff b)
	{
		GameObject buff = Instantiate(buffPanelPrefab);
		buff.transform.SetParent(transform);

		/*Text[] t = buff.GetComponentsInChildren<Text>();
		t[0].text = b.c.firstName;
		t[1].text = b.name;
		t[2].text = b.timer+"";
		
		buffsObject.Add(buff);
		buffs.Add(b);
	}

	public void removeBuff(Buff b)
	{
		int index = buffs.IndexOf(b);
		Destroy(buffsObject[index]);
		buffs.Remove(b);
		buffsObject.RemoveAt(index);
	}

	public void updateBuff(Buff b)
	{
		if(b.onTimer && b.timer == 0)
		{
			removeBuff(b);
			return;
		}
		int index = buffs.IndexOf(b);
		Text[] t = buffsObject[index].GetComponentsInChildren<Text>();
		t[0].text = b.c.firstName;
		t[1].text = b.name;
		t[2].text = b.timer + "";
	}*/
}
