/*
==========================================================
	controls everything on the options scene
==========================================================
The script exists on OptionsController prefab it manages 
changes in the options scene from what the sliders do to
setting preferences for jump guide.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider sfxVolumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private GameObject confirmReset;
	private MusicManager musicManager;	

	// Use this for initialization
	void Start () {
		musicManager = FindObjectOfType<MusicManager>();
		Debug.Log(musicManager);
		difficultySlider.value = PlayerPrefsManager.GetDiff();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		sfxVolumeSlider.value = PlayerPrefsManager.GetSFXVolume();		
		confirmReset = GameObject.Find("ConfirmReset");
		confirmReset.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		DiffSetter();
		musicManager.ChangeVolume (volumeSlider.value);	
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetSFXVolume(sfxVolumeSlider.value);
	}
	
	// Used on the exit button for the scene
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDiff(difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}

	/* Used on Default button
	 sets the volume default values. */
	public void SetDefaults(){
		volumeSlider.value = 0.65f;
		sfxVolumeSlider.value = 0.75f;
		difficultySlider.value = 0;
	}

	/* Used on Yes confirmation button 
	   resets data for all listed in the function */
	public void ResetAll()
	{
		PlayerPrefs.DeleteAll();
		SetDefaults();
		confirmReset.SetActive(false);
	}


	// turns on reset warning
	public void ResetBtn()
	{
		confirmReset.SetActive(true);
	}

	/* turns off reset warning
	this is on bothe the No button as well as the 
	image in the background of the warning screen. */
	public void ResetCancelBtn()
	{
		confirmReset.SetActive(false);
	}

	void DiffSetter()
	{
		if (difficultySlider.value == 1)
		{
			GameManager.HARDMODE = 1;
		}
		else if (difficultySlider.value == 2)
		{
			GameManager.HARDMODE = 1.3f;
		}
		else
		{
			GameManager.HARDMODE = 0.7f;
		}
	}
}
