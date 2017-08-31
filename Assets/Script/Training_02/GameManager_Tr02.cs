using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Tr02 : MonoBehaviour
{
    public GameCtrl_PanelChange GP;
    public PanelCrossChan_Ctrl PCC;

    [SerializeField]
    public List<GameObject> popUp;
    List<bool> isActivePopUp;
    bool isSetBug = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        popUp = new List<GameObject>(GameObject.FindGameObjectsWithTag("PopUp"));
        for (int i = 0; i < popUp.Count; i++)
        {
            isSetBug = true;
        }
        if (popUp.Count > 1)
        {
            // ここでバグ報告ボタンを押すとゲームクリアの判定を付ける
            isSetBug = true;
        }
        else
        {
            isSetBug = false;
        }
    }

    public void BugButton()
    {
        if (isSetBug)
        {
            for(int i = 0; i < popUp.Count; i++)
            {
                popUp[i].SetActive(false);
            }
            Debug.Log("Seikai");
            string daimei, section, syousai;

            GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);

            daimei = "クリアおめでとう～♪";
            section = "　・今回の不具合は";
            syousai = "バナーを同時押しするとダイアログが出てくる不具合だよ！\nどんな所に不具合があるかわからないから、見逃さない様に細かいところまで注意しなくちゃだね！";
            PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);
        }
        else if (!isSetBug)
        {
            /* 空白は何もしない */
        }
        else
        {
            Debug.Log("Matigai");
            string daimei, section, syousai;

            GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);

            daimei = "バグを見つけられなくて残念ね。。";
            section = "・次回からはこんな観点で挑戦してね！";
            syousai = "キーボードをいろいろ変えて、細かいところもチェックしてみて！";
            PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game);
        }
    }
}
