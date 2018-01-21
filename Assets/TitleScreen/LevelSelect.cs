using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public int lvlRep;
	public int lvlBuildNum;
	public bool lvlUnlock;
		
	private Text lvlText;

	// Use this for initialization
	void Start () {
		lvlText = GetComponentInChildren<Text>();
		lvlText.text = lvlRep.ToString();
		lvlUnlock = true;
	}

	public void LevelButton()
	{
		if (lvlUnlock)
		{
			SceneManager.LoadScene(lvlBuildNum);
		}
	}
}
