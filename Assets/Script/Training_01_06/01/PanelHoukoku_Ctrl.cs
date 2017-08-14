using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHoukoku_Ctrl : MonoBehaviour {

	public InputField DummyInput;
	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable () {
		StartCoroutine (ActInput());
	}

	IEnumerator ActInput()
	{
		yield return new WaitForSecondsRealtime (1.0f);
		DummyInput.ActivateInputField ();
	}

	public void InputChange()
	{
		if (DummyInput.text == "q") {
			Debug.Log ("Seikai");
			string daimei, section, syousai;

			GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

			daimei = "クリアおめでとう～♪";
			section = "・今回の不具合は";
			syousai = "特定のボタンがタップに反応しない不具合だよ！\nどんな所に不具合があるかわからないから、見逃さない様に細かいところまで注意しなくちゃだね！";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);
		} else if (DummyInput.text == "") {
			/* 空白は何もしない */
		} else {
			Debug.Log ("Matigai");
			string daimei, section, syousai;

			GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

			daimei = "バグを見つけられなくて残念ね。。";
			section = "・次回からはこんな観点で挑戦してね！";
			syousai = "キーボードをいろいろ変えて、細かいところもチェックしてみて！";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);
		}

		DummyInput.text = "";
	}

	public void GameGamenhe_Button()
	{
		GP.change_panel (GameCtrl_PanelChange.panel.Game, 1f, 1f);
	}
}
