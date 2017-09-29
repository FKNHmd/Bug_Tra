using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_Start_05 : MonoBehaviour {

    public GameCtrl_PanelChange GP;
    public PanelCrossChan_Ctrl PCC;

	// Use this for initialization
	void Start () {
		string daimei, section, syousai;

        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);

        daimei = "今回の仕様を説明するね♪";
		section = "";
		syousai = "私の顔が縦に並んでいて上下にスクロールできるよ！\nでもあることをすると表示が崩れるバグが発生するから見つけてバグ報告してね！\n";

        PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Normal, PanelCrossChan_Ctrl.crosschan_button.Game);
	}

	// Update is called once per frame
	void Update () {
		
	}


}
