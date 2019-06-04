using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonScript : MonoBehaviour
{

	public UsableItem item;
	public GameObject inventoryPanel;

	public void init(UsableItem item, GameObject inventoryPanel)
	{
		this.item = item;
		this.inventoryPanel = inventoryPanel;
		transform.GetComponentInChildren<Text>().text = item.name;
	}

	public void click()
	{
		Character player = CombatManager.Instance.currentPlayer;

		player.useItem = true;
		player.toUse = item;
		inventoryPanel.SetActive(false);

		CombatManager.Instance.populateAbilities(null, new Vector2(), null);
	}
}
