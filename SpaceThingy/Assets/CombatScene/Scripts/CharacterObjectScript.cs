using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObjectScript : MonoBehaviour
{
	public Character character;

	Animator animator;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update()
	{
		if (character.currentHp <= 0 && !animator.GetBool("dead"))
		{
			animator.SetBool("dead", true);
		}
		if (CombatManager.Instance.currentPlayer != character)
		{
			if (animator.GetBool("turn"))
			{
				animator.SetBool("turn", false);
			}
			return;
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			//character.doTurn(CombatManager.Instance.map);
		}

		animator.SetBool("turn", true);
	}

	public void setCharacter(Character c)
	{
		character = c;
		if(c.team == 0)
		{
			transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = c.type.spriteTeam1.texture;
		}
		else
		{
			transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = c.type.spriteTeam2.texture;
		}
	}

	/*void OnGUI()
	{
		if (!(character is AICharacter) || CombatManager.Instance.currentPlayer != character)
		{
			return;
		}
		List<Vector2> tiles = Helper.tilesInRange(character.loc, 3);
		List<Vector2> targets;
		List<float> shots = ((AICharacter)character).calculateUtilities(0, out targets, CombatManager.Instance.map);
		List<float> moves = ((AICharacter)character).calculateUtilities(-1, out targets, CombatManager.Instance.map);
		for (int i = 0; i < tiles.Count; i++)
		{
			Vector3 p = Camera.main.WorldToScreenPoint(new Vector3(tiles[i].x * CombatManager.Instance.tileSize + 1, tiles[i].y * CombatManager.Instance.tileSize + 1));
			GUI.color = Color.blue;
			GUI.Label(new Rect(p.x - 20, Screen.height - p.y + 20, 200, 200), "" + moves[i]);
			GUI.Label(new Rect(p.x - 20, Screen.height - p.y + 0, 200, 200), "" + shots[i]);
		}
	}*/
}
