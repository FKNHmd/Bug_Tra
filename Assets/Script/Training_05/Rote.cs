using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rote : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //スマホの左側が下になります
        Screen.autorotateToLandscapeLeft = true;
        //スマホの右側が下になります
        Screen.autorotateToLandscapeRight = true;
        //スマホの下が下になります
        Screen.autorotateToPortrait = true;
        //スマホの上が上になります
        Screen.autorotateToPortraitUpsideDown = false;
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
