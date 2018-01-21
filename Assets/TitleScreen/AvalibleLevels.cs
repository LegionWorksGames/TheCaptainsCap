using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvalibleLevels : MonoBehaviour {

	// The button you want to have spawn
	public GameObject lvlSelPrefab;
	[Tooltip("Build number of first level in build order")]
	public int lvlBuildStart;
	[Tooltip("Number of levels in Build order")]
	public int numOfLvls;

	// Sets horizontal and vertical number of spawns.
	public int xMax;

	private int xRow, yRow;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numOfLvls; i++)
		{			
			if (xRow >= xMax){
				xRow = 0;
				yRow++;
			}
			GameObject lvlSelClone = Instantiate(lvlSelPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform) as GameObject;
			lvlSelClone.transform.localPosition = new Vector3(xRow * 150, yRow * -150, 0);
			LevelSelect lvlSel = lvlSelClone.GetComponent<LevelSelect>();
			lvlSel.lvlBuildNum = i + lvlBuildStart;
			lvlSel.lvlRep = i+1;

			xRow++;
		}
	}	
}
