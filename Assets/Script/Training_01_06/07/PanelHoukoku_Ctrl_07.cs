using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHoukoku_Ctrl_07 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable () {
	}

	public void GameGamenhe_Button()
	{
		this.gameObject.SetActive (false);
		//GP.change_panel (GameCtrl_PanelChange.panel.Game);
	}

	public void zannen()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "バグを見つけられなくて残念ね。。";
		section = "・次回からはこんな観点で挑戦してね！";
		syousai = "音楽にノリノリになりすぎてバグを見つけれなかったのかな！？\n一般的な音楽プレイヤーだと、あのボタンを押すとあの動きをするはずなんだけどな～";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	public void seikai()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);
		daimei = "クリアおめでとう～♪";
		section = "　・今回の不具合は";
		syousai = "停止ボタンを押しても、音楽が止まらないバグだよ！\n基本動作が動いて当たり前と思っちゃダメだょ。\n動いて当たり前と思って確認を怠ると、後でひどい目にあっちゃうからね！";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

		/* セレクト画面でClear表示 */
		PlayerPrefs.SetInt ("ClearStat7", 1);
	}
}
