using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panelbutton_StageClearCheck : MonoBehaviour {

	//public GameObject[] ImageClear = new GameObject[9]; 

	// Use this for initialization
	void Start () {
		string key;
		string objname;
		for (int i = 1; i <= 9; i++) {
			key = "ClearStat" + i;
			objname = "Image Clear" + i;
			if (PlayerPrefs.GetInt (key) == 1) {
				GameObject.Find (objname).SetActive (true);
			} else {
				GameObject.Find (objname).SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
