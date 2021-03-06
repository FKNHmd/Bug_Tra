﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_06 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
	public Text TextNokoriByou;
	public Text TextCount;
	public GameObject ImageCrash;

	int count;
	float nokori;
	float oldtime, newtime, deltatime;
	bool clear_flg;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable () {
		count = 0;
		nokori = 11;
		TextCount.text = "" + count;
		TextNokoriByou.text = "" + (int)nokori;
		oldtime = Time.time;
		clear_flg = false;
	}
	
	// Update is called once per frame
	void Update () {
		nokori -= Time.deltaTime;
		TextNokoriByou.text = "" + (int)nokori;

		if ((nokori <= 0) && (clear_flg == false)) {
			string daimei, section, syousai;

			GP.change_panel (GameCtrl_PanelChange.panel.Crosschan, 1f, 0.12f);

			daimei = "バグを見つけられなくて残念ね。。";
			section = "・次回からはこんな観点で挑戦してね！";
			syousai = "ちょっと頑張りが足りないみたい。";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);

		}
	}

	public void countup()
	{
		newtime = Time.time;
		deltatime = newtime - oldtime;
		Debug.Log (deltatime);
		oldtime = newtime;

		if (deltatime < 0.07f) {
			clear_flg = true;
			StartCoroutine (crash_gizi ());
		}

		count++;
		TextCount.text = "" + count;
	}

	IEnumerator crash_gizi()
	{
		string daimei, section, syousai;

		ImageCrash.SetActive (true);
		yield return new WaitForSeconds(7f);
		ImageCrash.SetActive (false);

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan, 1f, 0.08f);
		daimei = "クリアおめでとう～♪";
		section = "　・今回の不具合は";
		syousai = "ボタンを速く連打するとアプリがクラッシュしちゃうバグだよ！\nクラッシュとは、アプリが突然異常終了することだよ。今回は疑似的なクラッシュだけどね！\n開発中のアプリは結構発生するんだけど、とても重大なバグなので本番のQAではリリース前に絶対見つけてね！";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);
	}
}
