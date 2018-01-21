using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberDisplay : MonoBehaviour {

	private LevelController lvlCont;
	private Text text;

	// Use this for initialization
	void Start () {
		lvlCont = FindObjectOfType<LevelController>();
		text = GetComponent<Text>();
		text.text = "Level: " + lvlCont.lvlNumber;
	}	
}
