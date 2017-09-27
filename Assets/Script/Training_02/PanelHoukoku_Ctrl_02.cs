using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHoukoku_Ctrl_02 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
	public Popup PUP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable () {
	}

	public void seikai()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		if (PUP.get_opennum () >= 2) {
			daimei = "クリアおめでとう～♪";
			section = "　・今回の不具合は";
			syousai = "ポップアップが重なって表示されるバグだよ！\n普段は重ならないように制御される部分だけど、たまに制御出来てなくて起きる事があるから注意してね！";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

            /* セレクト画面でClear表示 */
            PlayerPrefs.SetInt("ClearStat2", 1);
        } else {
			daimei = "残念だったね。。";
			section = "・次回からはこんな観点で挑戦してね！";
			syousai = "ただボタンを押すだけでなく、同時にボタンを押したりタイミングをずらして押したりして見てね！\nゲーム中、右上に出てくるヒントが出てくるよ！\n";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game, "リトライ");
		}
	}

	public void huseikai()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "残念だったね。。";
		section = "・次回からはこんな観点で挑戦してね！";
		syousai = "ただボタンを押すだけでなく、同時にボタンを押したりタイミングをずらして押したりしてみてね！\nゲーム中、右上に出てくるヒントが出てくるよ！\n";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game, "リトライ");
	}

	public void GameGamenhe_Button()
	{
		//GP.change_panel (GameCtrl_PanelChange.panel.Game);
		this.gameObject.SetActive(false);
	}
}
