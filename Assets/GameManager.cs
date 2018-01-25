using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType { classic, trial, endless }

public class GameManager {

	public static int LASTLEVELPLAYED, GEMS;
	public static float HARDMODE;
	public static int[] UPGRADE = new int[4];	
}
