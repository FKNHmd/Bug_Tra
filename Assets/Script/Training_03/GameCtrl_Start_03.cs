using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_03 : MonoBehaviour {

	//public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;

		//GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "今回の仕様を説明するね♪";
		section = "　今回はシューティングゲームだよ！";
		syousai = "ゲームスタートしたら左右にスワイプして青い箱を見つけてね！\n画面タップで弾が出るよ！\nその弾で青い箱を壊すとスコアが増えるから何点取れるか挑戦してね！\n遊びこめばあるバグが発生するから発生したら教えてね♪\n";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Normal, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Start_Button()
	{
		//GP.change_panel (GameCtrl_PanelChange.panel.Game);
	}
}
