using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_06 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
	public Text TextNokoriByou;
	public Text TextCount;

	int count;
	float nokori;
	float oldtime, newtime, deltatime;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable () {
		count = 0;
		nokori = 11;
		TextCount.text = "" + count;
		TextNokoriByou.text = "" + (int)nokori;
		oldtime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		nokori -= Time.deltaTime;
		TextNokoriByou.text = "" + (int)nokori;

		if (nokori <= 0) {
			string daimei, section, syousai;

			GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

			daimei = "バグを見つけられなくて残念ね。。";
			section = "・次回からはこんな観点で挑戦してね！";
			syousai = "ちょっと頑張りが足りないみたいね。";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);

		}
	}

	public void countup()
	{
		newtime = Time.time;
		deltatime = newtime - oldtime;
		Debug.Log (deltatime);
		oldtime = newtime;

		if (deltatime < 0.13f) {
			string daimei, section, syousai;

			GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

			daimei = "クリアおめでとう～♪";
			section = "・今回の不具合は";
			syousai = "ボタンの操作速度によって不正な動作が起きたバグだよ！";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);
		}

		count++;
		TextCount.text = "" + count;
	}
}
