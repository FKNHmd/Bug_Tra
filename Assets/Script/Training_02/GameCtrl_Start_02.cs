using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_02 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
	public Popup PUP1;
	public Popup PUP2;
	public Popup PUP3;
	public Popup PUP4;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "ゲームの仕様を説明するね♪";
		section = "・今回のゲームは";
		syousai = "ポップアップの表示動作を確認するゲームだよ！\n画面の中に不具合があるから頑張って見つけてね！\n";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Normal, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Start_Button()
	{
		pupup_reset ();
		GP.change_panel (GameCtrl_PanelChange.panel.Game);
	}

	void pupup_reset()
	{
		PUP1.Close ();
		PUP2.Close ();
		PUP3.Close ();
		PUP4.Close ();
		PUP1.opennum_reset ();
	}
}
