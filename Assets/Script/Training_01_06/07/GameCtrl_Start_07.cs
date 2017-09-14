using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_07 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "・今回の仕様を説明するね♪";
		section = "";
		syousai = "音楽プレイヤーで音楽が聴けるよ！\n下記の機能があるけど、ある機能だけバグがあるから見つけてね！\n\u3000音楽選択\n\u3000再生\n\u3000停止\n\u3000一時停止\n\u3000ミュート\n\u3000ミュート解除";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Normal, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Start_Button()
	{
		GP.change_panel (GameCtrl_PanelChange.panel.Game);
	}
}
