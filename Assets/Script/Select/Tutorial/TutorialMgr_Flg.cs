using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMgr_Flg : MonoBehaviour {

	GameObject gobj;

	// Use this for initialization
	void Start () {
		gobj = GameObject.Find ("Canvas Tutorial");
		if (PlayerPrefs.GetInt ("TutorialFlg") == 1) {
			gobj.SetActive (false);
		} else {
			PlayerPrefs.SetInt ("TutorialFlg", 1);
		}
	}

	public void tutorial_start ()
	{
		gobj.SetActive (true);
	}

	public void tutorial_close ()
	{
		gobj.SetActive (false);
	}
}
