using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "今回の仕様を説明するね♪";
		section = "";
		syousai = "キーボードで文字を入力するとホタルが光るよ！\n「ひらがな」「記号」「アルファベット」どんなキーボードの文字でも光るけど、ある特定の文字だけ光らないバグがあるからどの文字か見つけてね！";
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
