using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl_FixOrientation : MonoBehaviour {

	ScreenOrientation old_orientation;

	// Use this for initialization
	void Start () {
		old_orientation = Screen.orientation;

		Screen.orientation = ScreenOrientation.Portrait;

	}

	void OnDisable ()
	{
		Screen.orientation = old_orientation;
	}
}
