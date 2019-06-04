using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopInventory : MonoBehaviour
{
	public GameObject inventoryPanel;

	public void click()
	{
		if (!inventoryPanel.activeInHierarchy)
		{
			inventoryPanel.SetActive(true);
			inventoryPanel.transform.GetComponentInChildren<populateListScript>().populate(CombatManager.Instance.currentPlayer.inventory.getUsalbeItems());
		}
		else
		{
			inventoryPanel.SetActive(false);
		}
	}
}
