using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Tr02 : MonoBehaviour
{
    public GameCtrl_PanelChange GP;
    public PanelCrossChan_Ctrl PCC;

    [SerializeField]
    public List<GameObject> popUp;
    bool isSetBug = false;
    bool lasthint_flg = false;
    float lasthint_byou;

    bool isActivePopUp = false;

    // ポップアップをタップされた回数
    int tapCount = 0;
    [SerializeField]
    List<string> popUpName = new List<string>();
 public   HintManager _HintMar;

    // Use this for initialization
    void Start()
    {
        //_HintMar = GameObject.Find("HintObject").GetComponent<HintManager>();
        string naiyou = "ゲームのロゴをタップして\nポップアップを表示しよう！";
        _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
          }

    // Update is called once per frame
    void Update()
    {
        if (lasthint_flg)
        {
            lasthint_byou += Time.deltaTime;
            if (lasthint_byou > 15f)
            {
                string naiyou = "画面右上の「バグ報告」ボタンを押して、\n変な表示になっているところを教えよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                lasthint_byou = 0;
            }
        }
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
            for (int i = 0; i < popUp.Count; i++)
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

            /* セレクト画面でClear表示 */
            PlayerPrefs.SetInt("ClearStat2", 1);
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

            daimei ="残念だったね。。";
            section = "・次回からはこんな観点で挑戦してね！";
            syousai = "キーボードをいろいろ変えて、細かいところもチェックしてみて！";
            PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game, "リトライ");
        }
    }
    
    void WPopUp()
    {
        for(int i = 0; i < popUp.Count; i++)
        {
            if(popUp[i].transform.localScale.x != 0)
            {
                lasthint_flg = true;
            }
        }
        
    }

    public void PopUpTapCount(string name)
    {
        if (!popUpName.Contains(name))
        {
            if(tapCount == 0)
            {
                string naiyou = "ポップアップの画面右上にある\n「×」ボタンを押してポップアップを消そう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
            }
            tapCount++;
            popUpName.Add(name);
            if (tapCount == 4)
            {
                string naiyou = "ロゴを「連続タップ」「フリック」「スワイプ」\nその他いろんな操作をしてみよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
            }
        }
        if (!lasthint_flg)
        {
            WPopUp();
        }
    }
}
