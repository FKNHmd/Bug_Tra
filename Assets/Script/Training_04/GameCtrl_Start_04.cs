using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_04 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
   public HintManager _HintMar;

    // Use this for initialization
    void Start () {
		string daimei, section, syousai;

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan);

		daimei = "・今回の仕様を説明するね♪";
		section = "";
		syousai = "画面上部の入力フォームに必要事項を記載して入力ボタンを押してね！そうすると画面下部の表示エリアに入力した内容が反映されるよ！\nあることをすると表示エリアの表示がおかしくなるから、そのバグを見つけて教えてね！\n";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Normal, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Start_Button()
	{
		GP.change_panel (GameCtrl_PanelChange.panel.Game);
        //string naiyou = "名前と自己紹介を書いて\n入力ボタンをタップしよう！";
        //_HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
    }
}
