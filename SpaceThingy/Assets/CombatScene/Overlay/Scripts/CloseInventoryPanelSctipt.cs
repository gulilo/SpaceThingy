using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventoryPanelSctipt : MonoBehaviour
{
	public GameObject inventoryPanel;

	public void click()
	{
		inventoryPanel.SetActive(false);
	}
	
}
