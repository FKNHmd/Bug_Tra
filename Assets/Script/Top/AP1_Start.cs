using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AP1_Start : MonoBehaviour {

	public void StartButton ()
	{
		SceneSetAndLoad SSAL = GetComponent<SceneSetAndLoad> ();
		if (PlayerPrefs.GetInt ("TutorialFlg") == 1) {
			SSAL.NextScene = "Game_Select";
		} else {
			SSAL.NextScene = "Tutorial";
		}
		SSAL.SetAndLoadNextScene ();
	}
}
