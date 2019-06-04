using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
	public static CombatManager Instance { get; private set; }
	public CombatState state;


	public PupolateAbilitiesScript abilityPanel;
	public BuffPanelScript BuffPanel;

	public int numberOfEnemies;

	public bool running;

	public float tileSize;
	public int sizeX, sizeY;

	public GameObject winningPanel;
	public CharacterCreator characterCreator;

	public Character currentPlayer { get { return state.currentPlayer; } private set { state.currentPlayer = value; } }

	void Start()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		Instance = this;
		characterCreator = GameManager.Instance.gameObject.GetComponent<CharacterCreator>();
	}

	public void startCombat(CombatState state)
	{
		this.state = state;
		state.currentPlayer.startTurn();

		running = true;
	}

	public void characterDied(Character c)
	{
		state.characterDied(c);
	}

	private void endCombat()
	{
		currentPlayer = null;
		running = false;
	}

	public void gameOver()
	{
		endCombat();
		winningPanel.SetActive(true);
	}

	public void win()
	{
		endCombat();
		winningPanel.SetActive(true);
	}

	public void nextTurn()
	{
		state.nextTurn();
		populateAbilities(null, new Vector2(), null);
	}

	public void populateAbilities(List<Ability> abilities, Vector2 target, Character character)
	{
		abilityPanel.populate(abilities, target, character);
	}

	/*public void addBuff(Buff b)
	{
		BuffPanel.addBuff(b);
		b.activate();
		b.c.buffs.Add(b);
	}*/
/*
	public void removeBuff(Buff b)
	{
		b.deActivate();
		b.c.buffs.Remove(b);
	}*/

/*	public void moveCharacter(Vector2 from, Vector2 to)
	{
		map.moveCharacter(from, to);
	}*/

	/*public void updateBuffPanel(Buff b)
	{
		BuffPanel.updateBuff(b);
	}*/

	/*public void generateMap(MapType type)
	{
		map = mapGenerator.generateMap(type, sizeX, sizeY);
		generator.redrawMesh();
	}*/

	public void useAbility(Character character, Ability ability, Vector2 location)
	{
		character.useAbility(ability, location);
		populateAbilities(null, new Vector2(), null);
	}
}
