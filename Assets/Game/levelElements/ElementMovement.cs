using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMovement : MonoBehaviour {

	public float speed;
	public BlockSpawner spawner;
	private Vector3 v3_speed;

	private float move;

	void Start()
	{
		if (GameManager.HARDMODE > 0.5)
		{
			speed = GameManager.HARDMODE;
		}
		v3_speed = new Vector3(speed * -1, 0, 0);
	}

	void Update()
	{
		MovedOneUnit();
		Transform[] children = GetComponentsInChildren<Transform>();
		foreach (Transform child in children)
		{
			child.transform.Translate(Vector3.left * (speed * Time.deltaTime)); 
		}
	}

	public void MovedOneUnit()
	{
		move += (speed * Time.deltaTime);
		if (move >= 0.5f)
		{
			move = 0;
			spawner.SpawnController();
		}		
	}
}
