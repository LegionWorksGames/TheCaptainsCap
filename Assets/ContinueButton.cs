using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour {

	[Tooltip("Set to the index of the first Game level")]
	public int buildOffset;	
		
	public void ContinueBtn()
	{
		LevelManager lvlMan = FindObjectOfType<LevelManager>();
		int lvlLoad = GameManager.LASTLEVELPLAYED + buildOffset - 1;
		lvlMan.LoadLevel(lvlLoad);
	}
}
