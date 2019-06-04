using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SectorClickScript : MonoBehaviour
{

	// Update is called once per frame
	void FixedUpdate()
	{
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject == gameObject)
			{
				SceneManager.LoadScene("SceneCombat");
			}
		}

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];

			if (touch.phase == TouchPhase.Began)
			{
				Debug.Log("1");
				Vector2 touchPoss = touch.position;
				Vector2 touchPos = Camera.main.ScreenToWorldPoint(touchPoss);

				Collider2D hit = Physics2D.OverlapPoint(touchPos);
				Ray ray = Camera.main.ScreenPointToRay(touchPos);

				if (hit)
				{
					if (hit != null && hit.gameObject == gameObject)
					{
						SceneManager.LoadScene("SceneCombat");
					}
				}
			}
		}
#endif
	}
}
