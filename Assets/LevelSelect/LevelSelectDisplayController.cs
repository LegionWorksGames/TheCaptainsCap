using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectDisplayController : MonoBehaviour {

	public GameObject[] modes;
	
	// Use this for initialization
	void Start () {
		ModeButton(0);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ModeButton(int mode)
	{
		LevelSelectDisplayController lsdc = FindObjectOfType<LevelSelectDisplayController>();
		for (int i = 0; i < lsdc.modes.Length; i++)
		{
			lsdc.modes[i].gameObject.SetActive(false);
		}
		lsdc.modes[mode].gameObject.SetActive(true);
	}
}
