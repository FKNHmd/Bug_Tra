using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_05 : MonoBehaviour {

	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;


		daimei = "ゲームの仕様を説明するね♪";
		section = "　・今回のゲームは";
		syousai = "画面のどこかに黒い画像が表示されてしまう不具合だよ！\nこのままじゃ見つからないから頭を回転して見つけてね！\n";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Normal, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	// Update is called once per frame
	void Update () {
		
	}


}
