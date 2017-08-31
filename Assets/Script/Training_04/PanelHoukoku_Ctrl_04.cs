using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHoukoku_Ctrl_04 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void seikai()
    {
        string daimei, section, syousai;
        GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);

        daimei = "クリアおめでとう～♪";
        section = "　・今回の不具合は";
        syousai = "特定の文字数以上入力した際に、改行されないでUI崩れがおきてしまう不具合だよ！\nいつもと違う違和感を感じることが出来たらサイコーだね！\nその為にはゲームを沢山プレイして、仕様を把握しておくことが大切だょ♪";
        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);
    }

    public void fuseikai()
    {
        string daimei, section, syousai;
        GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);

        daimei = "バグを見つけられなくて残念ね･･･。";
        section = "・次回からはこんな観点で挑戦してね！";
        syousai = "「入力欄」や「入力ボタン」を押したあと等に、注目してみてっ！文字列等には様々な不具合がおおいので注意して見てみてね！";
        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);
    }
	public void GameGamenhe_Button()
	{
        //GP.change_panel (GameCtrl_PanelChange.panel.Game);
        this.gameObject.SetActive(false);
	}
}
