using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
	
	public GameType gameType;
	public int levelDurationInSeconds, lvlNumber;
	public Slider timeSlider;
	public GameObject hat, player;	

	private LevelManager levelManager;	

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		GameManager.LASTLEVELPLAYED = lvlNumber;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < levelDurationInSeconds)
		{
			timeSlider.value = Time.timeSinceLevelLoad / levelDurationInSeconds;
		}
		else
		{
			float step = 3 * Time.deltaTime;
			hat.transform.position = Vector3.MoveTowards(hat.transform.position, player.transform.position, step);
		}
	}
}
