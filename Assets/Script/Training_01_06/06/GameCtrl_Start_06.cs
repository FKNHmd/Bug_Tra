using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_06 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "・今回の仕様を説明するね♪";
		section = "";
		syousai = "10秒間の間ボタンを連打して連打数を表示するよ！\nでも、連打を頑張っているとある重大なバグが発生するよ！\n今回はバグ報告ボタンはなくて、バグが発生すると勝手に結果画面に遷移するからびっくりしないでね！\n";
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
