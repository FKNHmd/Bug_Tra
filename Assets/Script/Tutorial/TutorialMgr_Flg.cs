using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMgr_Flg : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("TutorialFlg", 1);
	}
}
