using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHoukoku_Ctrl_08 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
	public GameCtrl_ClearCheck_08 GCC;
	public GameObject ButtonSeikai;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable () {
		if (GCC.get_clearflg () == true) {
			ButtonSeikai.SetActive (true);
		}
	}

	public void GameGamenhe_Button()
	{
		//GP.change_panel (GameCtrl_PanelChange.panel.Game);
		this.gameObject.SetActive (false);
	}

	public void huseikai()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "バグを見つけられなくて残念ね。。";
		section = "・次回からはこんな観点で挑戦してね！";
		syousai = "欲しいキャラが出なかった時に思わずしちゃいそうな操作を考えてみて！";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	public void seikai()
	{
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);
		daimei = "クリアおめでとう～♪";
		section = "・今回の不具合は";
		syousai = "ガチャをひいて、結果がわかった後にサスペンド/レジューム(サスレジ)すると、コインが減ってない状態でまたガチャがひけてしまうバグだよ！\n"
			+ "今回のバグはユーザーが得する不具合だけど、本番のQAではコインだけ減ってキャラを取得できないといったユーザーが損するといったこともないか確認してね！"
			+ "また、ガチャ結果がわかった瞬間にネットワーク切断やブラウザバック等で問題発生することもあるから注意だよ！";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

	}
}
