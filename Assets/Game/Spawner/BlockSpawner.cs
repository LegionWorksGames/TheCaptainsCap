/* Spawns new blocks
 * DEPENDENCIES
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public GameObject tilesPrefab;
	public BlockSpawner spawnerAbove;
	public Sprite[] tileSprites;
	public int spawnRate, spawnThreshold;
	public bool stackable, baseLayer;

	private ElementMovement holder;
	private int notSpawned = 0;


	void Start()
	{
		holder = FindObjectOfType<ElementMovement>();
	}	

	void SpawnBlocks()
	{
		GameObject tiles = Instantiate(tilesPrefab, transform.position, Quaternion.identity);
		SpriteRenderer setSprite = tiles.GetComponent<SpriteRenderer>();
		int spriteNum = Random.Range(0, tileSprites.Length);
		setSprite.sprite = tileSprites[spriteNum];
		tiles.transform.parent = holder.transform;		
		if (stackable)
		{
			spawnerAbove.SpawnController();
		}
	}

	public void SpawnController()
	{		
		if (notSpawned >= spawnThreshold && baseLayer)
		{
			SpawnBlocks();
			notSpawned = 0;			
		}
		else 
		{
			int rand = Random.Range(1, 100);
			if (rand <= spawnRate)
			{
				SpawnBlocks();				
			}
			else
			{
				if (baseLayer) { notSpawned++; }
			}
		}		
	}
}
