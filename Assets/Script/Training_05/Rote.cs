using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rote : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // 自動回転可能にする
        Screen.orientation = ScreenOrientation.AutoRotation;
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

    private void OnDisable()
    {
        // スマホの縦画面のみを許可
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }
}
