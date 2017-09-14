using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_08 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
	public GameCtrl_ClearCheck_08 GCC;
	public GameObject ButtonSeikai;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "・今回の仕様を説明するね♪";
		section = "";
		syousai = "コイン100を消費してガチャをまわせるよ！超絶レアの☆５のキャラをゲットしよう！\n今回のバグは画面上のチェックだけじゃなくて、端末全体でいろいろな操作をして見つけてね！";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Normal, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Start_Button()
	{
		GCC.set_clearflg (false);
		ButtonSeikai.SetActive (false);
		GP.change_panel (GameCtrl_PanelChange.panel.Game);
	}
}
