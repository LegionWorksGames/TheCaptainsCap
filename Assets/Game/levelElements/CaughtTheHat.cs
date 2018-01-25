using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtTheHat : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			LevelController lvlcont = FindObjectOfType<LevelController>();
			if (lvlcont.gameType == GameType.classic)
			{
				if (lvlcont.levelDurationInSeconds > Time.timeSinceLevelLoad)
				{					
					GameManager.GEMS += 10 + (5 * lvlcont.lvlNumber);
				}
				else
				{
					GameManager.GEMS += 10;
				}				
			}
			else if (lvlcont.gameType == GameType.trial)
			{

			}
			levelManager.LoadNextLevel();
		}
	}
}
