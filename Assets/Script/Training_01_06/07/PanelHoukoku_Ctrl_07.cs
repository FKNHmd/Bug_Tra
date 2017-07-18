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
		GP.change_panel (GameCtrl_PanelChange.panel.Game);
	}

	public void play_button()
	{
		zannen ();
	}

	public void teisi_button()
	{
		seikai ();
	}

	public void itiziteisi_button()
	{
		zannen ();
	}

	public void valume_button()
	{
		zannen ();
	}

	public void mute_button()
	{
		zannen ();
	}

	void zannen()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "バグを見つけられなくて残念ね。。";
		section = "・次回からはこんな観点で挑戦してね！";
		syousai = "一般的な音楽プレイヤーだと、あのボタンを押すとあの動きをするはずなんだけどな～";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	void seikai()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);
		daimei = "クリアおめでとう～♪";
		section = "・今回の不具合は";
		syousai = "停止ボタンを押しても、音楽が止まらないバグだよ！";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

	}
}
