using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

	private LevelManager levelManager;

	void Start()
	{
		levelManager = FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//spawner.SpawnController();
		if (col.gameObject.CompareTag("Player"))
		{
			levelManager.LoadLevel("03b Lose");
		}
		Destroy(col.gameObject);
	}
}
