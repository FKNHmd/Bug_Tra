﻿using System.Collections;
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

		daimei = "ゲームの仕様を説明するね♪";
		section = "　・今回のゲームは";
		syousai = "音楽プレイヤーのゲームだよ！\nいろいろなボタンを押してバグを見つけてね！\n不具合を見つけたら「Bug報告」ボタンをタップしてバグを教えてね♪";
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
